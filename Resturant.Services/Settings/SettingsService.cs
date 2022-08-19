using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Data;
using Resturant.Data.DbModels.BusinessSchema;
using Resturant.DTO.Business.Press;
using Resturant.DTO.Business.Settings;
using Resturant.Services.UploadFiles;

namespace Resturant.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly AppDbContext _context;
        private readonly IResponseDTO _response;
        private readonly IUploadFilesService _uploadFilesService;

        public SettingsService(AppDbContext context, IResponseDTO response, IUploadFilesService uploadFilesService)
        {
            _context = context;
            _response = response;
            _uploadFilesService = uploadFilesService;
        }
        public async Task<SettingsDetailsDto> SettingsDetails(string serverRootPath)
        {
            var settings = await _context.Settings.FirstOrDefaultAsync();
            var mapping = settings.Adapt<SettingsDetailsDto>();

            if (mapping.PrivateDiningAttachmentPath != null)
            {
                if (mapping.PrivateDiningAttachmentPath.StartsWith("\\"))
                {
                    if (!string.IsNullOrEmpty(mapping.PrivateDiningAttachmentPath))
                    {
                        mapping.PrivateDiningAttachmentPath = serverRootPath + mapping.PrivateDiningAttachmentPath.Replace('\\', '/');
                    }
                }
            }
            return mapping;
        }
        public async Task<IResponseDTO> UpdateAboutUsSettings(UpdateSettingsDto options)
        {
            try
            {
                var settings = await _context.Settings.FirstOrDefaultAsync();
                settings.AboutUs = options.AboutUs;
                settings.EmailService = options.EmailService;
                settings.NumberService = options.NumberService;
                settings.WorkWithUsDescription = options.WorkWithUsDescription;

                _context.Settings.Attach(settings);
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
        public async Task<IResponseDTO> UpdatePrivateDining(UpdateSettingsDto options)
        {
            try
            {
                var settings = await _context.Settings.FirstOrDefaultAsync();
                if (options.Document != null)
                {
                Random rnd = new Random();
                var path = $"\\Uploads\\PrivateDining\\PrivateDining_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                var attachmentPath = $"{path}\\{options.Document?.FileName}";

                settings.PrivateDiningAttachmentPath = attachmentPath;
                settings.PrivateDiningAttachmentName = options.Document?.FileName;
                await _uploadFilesService.UploadFile(path, options.Document);

                }

                settings.PrivateDiningDescription = options.PrivateDiningDescription;
                _context.Settings.Attach(settings);
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
