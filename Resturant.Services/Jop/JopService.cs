using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Business.Jop;
using Resturant.DTO.Business.Manue;
using Resturant.DTO.Lookup.EventType;
using Resturant.Services.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Jop
{
    public class JopService : IJopService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;
        public JopService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }
        public async Task<IResponseDTO> DeleteSubmitedJop(Guid Id)
        {
            try
            {
                var Jop = await _context.Jops.FindAsync(Id);
                if (Jop == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                Jop.IsDeleted = true;
                Jop.UpdatedOn = DateTime.Now;

                // save to the database
                _context.Jops.Attach(Jop);
                await _context.SaveChangesAsync();
                await _uploadFilesService.DeleteFile(Jop?.AttachmentPath);

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
        public  PaginationResult<jopForReturnDto> GetAll(BaseFilterDto filterDto)
        {
            var paginationResult = _context.Jops.Where(J=>J.IsDeleted== false).AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);

            var dataList = paginationResult.list.Adapt<List<jopForReturnDto>>();

            return new PaginationResult<jopForReturnDto>(dataList, paginationResult.total);
        }
        public async Task<IResponseDTO> SubmitInJopFormCreate(CreateJopDto createJopDto)
        {
            try
            {

                foreach (var image in createJopDto.Attachment)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Jop\\Jop_{DateTime.Now}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{image?.FileName}";

                    var Jop = new Data.DbModels.BusinessSchema.Jop()
                    {
                        Name = createJopDto.Name,
                        CoverLatter = createJopDto.CoverLatter,
                        PhoneNumber = createJopDto.PhoneNumber,
                        Email = createJopDto.Email,
                        AttachmentPath=attachmentPath
                    };

                    await _context.Jops.AddAsync(Jop);
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
