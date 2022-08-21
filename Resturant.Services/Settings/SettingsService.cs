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
            var mapping = settings!.Adapt<SettingsDetailsDto>();

            if (mapping.PrivateDiningAttachmentPath != null && mapping.privateDiningCoverAttachmentPath != null && mapping.AboutAttachmentPath != null
                && mapping.ManuAttachmentPath != null)
            {
                if (mapping.PrivateDiningAttachmentPath.StartsWith("\\") || mapping.privateDiningCoverAttachmentPath.StartsWith("\\") ||
                     mapping.AboutAttachmentPath.StartsWith("\\") || mapping.ManuAttachmentPath.StartsWith("\\"))
                {
                    if (!string.IsNullOrEmpty(mapping.PrivateDiningAttachmentPath))
                    {
                        mapping.PrivateDiningAttachmentPath = serverRootPath + mapping.PrivateDiningAttachmentPath.Replace('\\', '/');
                        mapping.privateDiningCoverAttachmentPath = serverRootPath + mapping.privateDiningCoverAttachmentPath.Replace('\\', '/');
                        mapping.AboutAttachmentPath = serverRootPath + mapping.AboutAttachmentPath.Replace('\\', '/');
                        mapping.ManuAttachmentPath = serverRootPath + mapping.ManuAttachmentPath.Replace('\\', '/');
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
                settings.UpdatedOn = DateTime.Now;

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
        public async Task<IResponseDTO> UploadAboutCover(AboutCoverDto options)
        {
            try
            {
                var settings = await _context.Settings.FirstOrDefaultAsync();
                if (options.AboutCover != null)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Covers\\AboutCover{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{options.AboutCover?.FileName}";

                    settings!.AboutAttachmentPath = attachmentPath;
                    settings.AboutAttachmentName = options.AboutCover?.FileName;
                    await _uploadFilesService.UploadFile(path, options.AboutCover);
                    settings.UpdatedOn = DateTime.Now;
                }
                _context.Settings.Attach(settings!);
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
        public async Task<IResponseDTO> UploadMenuCover(ManuCoverDto options)
        {
            try
            {
                var settings = await _context.Settings.FirstOrDefaultAsync();
                if (options.ManuCover != null)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Covers\\ManuCover{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{options.ManuCover?.FileName}";

                    settings!.ManuAttachmentPath = attachmentPath;
                    settings.ManuAttachmentName = options.ManuCover?.FileName;
                    await _uploadFilesService.UploadFile(path, options.ManuCover);
                    settings.UpdatedOn = DateTime.Now;
                }
                _context.Settings.Attach(settings!);
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
        public async Task<IResponseDTO> UploadPrivateDiningCover(PrivateDininCoverDto options)
        {
            try
            {
                var settings = await _context.Settings.FirstOrDefaultAsync();
                if (options.PrivateDiningCover != null)
                {
                    Random rnd = new Random();
                    var path = $"\\Uploads\\Covers\\PrivateDiningCover{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
                    var attachmentPath = $"{path}\\{options.PrivateDiningCover?.FileName}";

                    settings!.privateDiningCoverAttachmentPath = attachmentPath;
                    settings.privateDiningCoverAttachmentName = options.PrivateDiningCover?.FileName;
                    await _uploadFilesService.UploadFile(path, options.PrivateDiningCover);
                    settings.UpdatedOn = DateTime.Now;
                }
                _context.Settings.Attach(settings!);
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
