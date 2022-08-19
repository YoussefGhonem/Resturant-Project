using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.DTO.Business.ContactUs;
using Resturant.DTO.Business.Jop;
using Resturant.Services.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.ContectUs
{
    public class ContactUsService : IContactUs
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        public ContactUsService(AppDbContext context, IResponseDTO response)
        {
            _context = context;
            _response = response;
        }
        public async Task<IResponseDTO> CreateContactUs(CreateContactUsDto dreateContactUsDto)
        {
            try
            {
                var ContactUs = new Data.DbModels.BusinessSchema.ConntactUs()
                {
                    Name = dreateContactUsDto.Name,
                    PhoneNumber = dreateContactUsDto.PhoneNumber,
                    Email = dreateContactUsDto.Email,
                    TouchAbout = dreateContactUsDto.TouchAbout,
                    Massage = dreateContactUsDto.Massage

                };

                await _context.ConntactUss.AddAsync(ContactUs);
                await _context.SaveChangesAsync();
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
        public async Task<IResponseDTO> DeletContactUs(Guid Id)
        {
            try
            {
                var ConntactUs = await _context.ConntactUss.FindAsync(Id);
                if (ConntactUs == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                ConntactUs.IsDeleted = true;
                ConntactUs.UpdatedOn = DateTime.Now;

                // save to the database
                _context.ConntactUss.Attach(ConntactUs);
                await _context.SaveChangesAsync();
                _response.IsPassed = true;

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
        public PaginationResult<ContactUsReturnDto> GetAllContactUs(BaseFilterDto filterDto)
        {
            var paginationResult = _context.ConntactUss.Where(J => J.IsDeleted == false).AsNoTracking().Paginate(filterDto.PageSize, filterDto.PageNumber);
            var dataList = paginationResult.list.Adapt<List<ContactUsReturnDto>>();
            return new PaginationResult<ContactUsReturnDto>(dataList, paginationResult.total);
        }
    }
}
