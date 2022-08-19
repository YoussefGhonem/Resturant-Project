using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.BusinessSchema;
using Resturant.DTO.Business.Press;
using Resturant.Services.UploadFiles;

namespace Resturant.Services.Press
{
    public class PressService : IPressService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;

        public PressService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }
        public async Task<IResponseDTO> CreatePress(CreateUpdatePressDto options)
        {
            try
            {
                Random rnd = new Random();
                var path = $"\\Uploads\\Press\\Press_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                var attachmentPath = $"{path}\\{options.Image?.FileName}";

                var press = new Data.DbModels.BusinessSchema.Press()
                {
                    Title = options.Title,
                    Description = options.Description,
                    HyperLink = options.HyperLink,
                    AttachmentName = options.Image?.FileName,
                    AttachmentPath = attachmentPath,
                    AttachmentExtension = string.Empty,
                };

                await _context.Press.AddAsync(press);
                await _context.SaveChangesAsync();
                await _uploadFilesService.UploadFile(path, options.Image);

                _response.IsPassed = true;
                return _response;

            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }

            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
        public PaginationResult<PressDataListDto> GetAll(BaseFilterDto filterDto, string serverRootPath)
        {
            var paginationResult = _context.Press.AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.Adapt<List<PressDataListDto>>();

            foreach (var item in dataList)
            {

                if (item.AttachmentPath != null)
                {
                    if (item.AttachmentPath.StartsWith("\\"))
                    {
                        if (!string.IsNullOrEmpty(item.AttachmentPath))
                        {

                            item.AttachmentPath = serverRootPath + item.AttachmentPath.Replace('\\', '/');
                        }

                    }
                }
            }

            return new PaginationResult<PressDataListDto>(dataList, paginationResult.total);
        }
        public async Task<IResponseDTO> RemovePress(Guid id)
        {
            try
            {
                var press = await _context.Press.FindAsync(id);
                if (press == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                press.IsDeleted = true;
                press.UpdatedOn = DateTime.Now;

                // save to the database
                _context.Press.Attach(press);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }
            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;

        }
        public async Task<IResponseDTO> UpdatePress(Guid id, CreateUpdatePressDto options)
        {
            try
            {
                var press = await _context.Press.FindAsync(id);
                if (press == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                press.Title = options.Title;
                press.HyperLink = options.HyperLink;
                press.Description = options.Description;
                press.UpdatedOn = DateTime.Now;

                // save to the database
                _context.Press.Attach(press);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }
            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
        public async Task<IResponseDTO> UpdateImagePress(Guid id, IFormFile image)
        {
            try
            {
                Random rnd = new Random();
                var path = $"\\Uploads\\Press\\Press_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                var attachmentPath = $"{path}\\{image?.FileName}";

                var press = await _context.Press.FindAsync(id);
                if (press == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                press.AttachmentName = image?.FileName;
                press.AttachmentPath = attachmentPath;
                press.UpdatedOn = DateTime.Now;

                // save to the database
                _context.Press.Attach(press);
                await _context.SaveChangesAsync();
                await _uploadFilesService.UploadFile(path, image);

            }
            catch (Exception ex)
            {
                _response.Data = null;
                _response.IsPassed = false;
                _response.Errors.Add($"Error: {ex.Message}");
            }
            if (_response.Errors.Count > 0)
            {
                _response.Errors = _response.Errors.Distinct().ToList();
                _response.IsPassed = false;
                _response.Data = null;
                return _response;
            }
            return _response;
        }
    }
}
