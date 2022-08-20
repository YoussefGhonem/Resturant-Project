using Mapster;
using Microsoft.EntityFrameworkCore;
using Nest;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Business.Cover;
using Resturant.DTO.Business.Gallery;
using Resturant.Services.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Cover
{
    public class CoverService : ICover
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;
        public CoverService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }
        public async Task<IResponseDTO> DeleteImageCover(Guid Id)
        {
            try
            {
                var Image = await _context.Covers.FindAsync(Id);
                if (Image == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                Image.IsDeleted = true;
                Image.UpdatedOn = DateTime.Now;

                // save to the database
                _context.Covers.Attach(Image);
                await _context.SaveChangesAsync();
                await _uploadFilesService.DeleteFile(Image?.ImageUrl);

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
            //throw new NotImplementedException();
        }

        public PaginationResult<CoverReturnDro> GetAllCover(BaseFilterDto filterDto, string serverRootPath)
        {
            var paginationResult = _context.Covers.Where(G => G.IsDeleted == false).AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.Adapt<List<CoverReturnDro>>();

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

            return new PaginationResult<CoverReturnDro>(dataList, paginationResult.total);
        }

        public async Task<IResponseDTO> UploadImageCover(CreateAndUpdateCoverDto createAndUpdateCoverDto)
        {
            try
            {
                if (!createAndUpdateCoverDto.Images.Any())
                {
                    _response.IsPassed = false;
                    _response.Data = null;
                    return _response;
                };

                foreach (var image in createAndUpdateCoverDto.Images)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Cover\\Cover{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{image?.FileName}";

                    var obj = new Data.DbModels.BusinessSchema.Cover()
                    {
                        ImageName = image?.FileName,
                        ImageUrl = attachmentPath,
                    };

                    await _context.Covers.AddAsync(obj);
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
    }
}
