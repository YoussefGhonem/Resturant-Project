using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Business.Cover;
using Resturant.DTO.Business.Happining;
using Resturant.Services.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Happining
{
    public class HappiningService : IHappining
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;
        public HappiningService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }
        public async Task<IResponseDTO> CreateHappining(CreateAndUpdateHappiningDto options)
        {
            try
            {
                if (options.Image == null)
                {
                    _response.IsPassed = false;
                    _response.Data = null;
                    return _response;
                };


                Random rnd = new Random();
                var path = $"\\Uploads\\Happining\\Happining{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                var attachmentPath = $"{path}\\{options.Image?.FileName}";

                var obj = new Data.DbModels.BusinessSchema.Happining()
                {
                    ImageName = options.Image?.FileName,
                    ImageUrl = attachmentPath,
                    Description = options.Description,
                    Title = options.Title
                };

                await _context.Happinings.AddAsync(obj);
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
        public async Task<IResponseDTO> DeleteHappining(Guid Id)
        {
            try
            {
                var Happining = await _context.Happinings.FindAsync(Id);
                if (Happining == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                Happining.IsDeleted = true;
                Happining.UpdatedOn = DateTime.Now;

                // save to the database
                _context.Happinings.Attach(Happining);
                await _context.SaveChangesAsync();
                await _uploadFilesService.DeleteFile(Happining?.ImageUrl);

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
        public PaginationResult<HappiningReturnDto> GetAllHappining(BaseFilterDto filterDto, string serverRootPath)
        {
            var paginationResult = _context.Happinings.Where(G => G.IsDeleted == false).AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);
            var dataList = paginationResult.list.Adapt<List<HappiningReturnDto>>();
            foreach (var item in dataList)
            {
                if (item.ImageUrl != null)
                {
                    if (item.ImageUrl.StartsWith("\\"))
                    {
                        if (!string.IsNullOrEmpty(item.ImageUrl))
                        {
                            item.ImageUrl = serverRootPath + item.ImageUrl.Replace('\\', '/');
                        }
                    }
                }
            }
            return new PaginationResult<HappiningReturnDto>(dataList, paginationResult.total);
        }
    }
}
