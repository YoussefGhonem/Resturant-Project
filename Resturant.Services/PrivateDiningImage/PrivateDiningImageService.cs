using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Business.PrivateDiningImage;
using Resturant.Services.UploadFiles;

namespace Resturant.Services.PrivateDiningImage
{
    public class PrivateDiningImageService : IPrivateDiningImageService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;

        public PrivateDiningImageService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }
        public async Task<IResponseDTO> Create(CreatePrivateDiningImageDto options)
        {
            try
            {
                foreach (var image in options.Images)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\PrivateDining\\PrivateDining_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{image?.FileName}";

                    var obj = new Data.DbModels.BusinessSchema.PrivateDiningImage()
                    {
                        AttachmentPath = attachmentPath,
                        AttachmentName = image?.Name,
                    };

                    await _context.PrivateDiningImages.AddAsync(obj);
                    await _context.SaveChangesAsync();
                    await _uploadFilesService.UploadFile(path, image);
                }

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
        public PaginationResult<PrivateDiningImageListDto> GetAll(BaseFilterDto filterDto, string serverRootPath)
        {
            var paginationResult = _context.PrivateDiningImages.AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.Adapt<List<PrivateDiningImageListDto>>();

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

            return new PaginationResult<PrivateDiningImageListDto>(dataList, paginationResult.total);
        }
        public async Task<IResponseDTO> Remove(Guid id)
        {
            try
            {
                var obj = await _context.PrivateDiningImages.FindAsync(id);
                if (obj == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object id";
                    return _response;
                }

                // Set Data
                obj.IsDeleted = true;
                obj.UpdatedOn = DateTime.Now;

                // save to the database
                _context.PrivateDiningImages.Attach(obj);
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
    }
}
