using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.BusinessSchema;
using Resturant.DTO.Business.Gallery;
using Resturant.DTO.Business.PrivateDiningImage;
using Resturant.Services.UploadFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Gallery
{
    public class GalleryService : IGalleryService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;
        public GalleryService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }
        public async Task<IResponseDTO> DeleteImage(Guid Id)
        {
            try
            {
                var Image = await _context.Gallerys.FindAsync(Id);
                if (Image == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                Image.IsDeleted = true;
                Image.UpdatedOn = DateTime.Now;

                // save to the database
                _context.Gallerys.Attach(Image);
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
        }
        public PaginationResult<GalleryReturnDto> GetAllWithPagination(BaseFilterDto filterDto, string serverRootPath)
        {
            var paginationResult = _context.Gallerys.Where(G => G.IsDeleted == false).AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.Adapt<List<GalleryReturnDto>>();

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

            return new PaginationResult<GalleryReturnDto>(dataList, paginationResult.total);
        }
        public async Task<IEnumerable<GalleryReturnDto>> GetAllImagesForGallary()
        {
            var Images = await _context.Gallerys.Where(G => G.IsDeleted == false).ToListAsync();
            var ImageToReturn = Images.Adapt<IEnumerable<GalleryReturnDto>>();
            return ImageToReturn;
        }
        public async Task<IResponseDTO> UploadNewImage(CreateAndUpdateGalleryDto createAndUpdateGallery)
        {
            try
            {
                if (!createAndUpdateGallery.Images.Any())
                {
                    _response.IsPassed = false;
                    _response.Data = null;
                    return _response;
                };

                foreach (var image in createAndUpdateGallery.Images)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Gallery\\Gallery_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{image?.FileName}";

                    var obj = new Data.DbModels.BusinessSchema.Gallery()
                    {
                        Name = createAndUpdateGallery?.Name,
                        ImageUrl = attachmentPath,

                    };

                    await _context.Gallerys.AddAsync(obj);
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
