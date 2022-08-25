using Mapster;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.BusinessSchema.About;
using Resturant.DTO.Business.AboutAndCommuniry;
using Resturant.DTO.Business.ContactUs;
using Resturant.DTO.Business.WhyUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Resturant.Services.WhyUs
{
    public class WhyUsService : IWhyUs
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;

        public WhyUsService(AppDbContext context, IResponseDTO response)
        {
            _context = context;
            _response = response;
        }
        public async Task<IResponseDTO> CreateWhyUs(List<CreateAndUpdateWhyUsDto> options)
        {
           try
            {
                foreach (var item in options)
                {
                    var WhyUs = new Data.DbModels.BusinessSchema.About.WhyUs()
                    {
                        Answer = item.Answer,
                        Quetion = item.Quetion
                    };
                    await _context.WhyUss.AddAsync(WhyUs);
                    await _context.SaveChangesAsync();
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
        public async Task<IResponseDTO> DeleteWhyUs(Guid Id)
        {
            try
            {
                var WhyUs = await _context.WhyUss.FindAsync(Id);
                if (WhyUs == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }
                WhyUs.IsDeleted = true;
                WhyUs.UpdatedOn = DateTime.Now;

                // save to the database
                _context.WhyUss.Attach(WhyUs);
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

        public async Task<IEnumerable<ReturnWhyUsDto>> GetAllWhyUs()
        {
            var WhyUs = await _context.WhyUss.Where(T => T.IsDeleted == false).OrderByDescending(w=>w.CreatedOn).Take(3).ToListAsync();
            var WhyUsForReturn = WhyUs.Adapt<IEnumerable<ReturnWhyUsDto>>();            
            return WhyUsForReturn;
        }

        public async Task<IResponseDTO> UpdateWhyUs(CreateAndUpdateWhyUsDto options,Guid Id)
        {
            try
            {
                var OnlyOneWhyUS = await _context.WhyUss.FindAsync(Id);
                if (OnlyOneWhyUS == null)
                {
                    _response.IsPassed = false;
                    _response.Message = "Invalid object Id";
                    return _response;
                }

                OnlyOneWhyUS.Answer = options?.Answer;
                OnlyOneWhyUS.Quetion = options?.Quetion;
                _context.WhyUss.Attach(OnlyOneWhyUS);
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
    }
}
