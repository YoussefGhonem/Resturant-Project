using Microsoft.Extensions.DependencyInjection;
using Resturant.Core.Common;
using Resturant.Core.Interfaces;
using Resturant.Services.AboutAndCommunity;
using Resturant.Services.ContectUs;
using Resturant.Services.EventType;
using Resturant.Services.Gallery;
using Resturant.Services.Identity;
using Resturant.Services.Location;
using Resturant.Services.Jop;
using Resturant.Services.Manue;
using Resturant.Services.Press;
using Resturant.Services.PrivateDining;
using Resturant.Services.PrivateDiningImage;
using Resturant.Services.SendingEmail;
using Resturant.Services.Settings;
using Resturant.Services.UploadFiles;

namespace Resturant.Services
{
    public static class AutoFacInternalConfiguration
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services)
        {
            services.AddTransient<ISendingEmailService, SendingEmailService>();
            services.AddScoped<IIdentityServices, IdentityServices>();
            services.AddScoped<IResponseDTO, ResponseDTO>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IUploadFilesService, UploadFilesService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<IPrivateDiningService, PrivateDiningService>();
            services.AddScoped<IPrivateDiningImageService, PrivateDiningImageService>();
            services.AddScoped<IManuesService, ManueService>();
            services.AddScoped<IPressService, PressService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IAboutAndComunity, AboutAndCommunityService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IJopService, JopService>();
            services.AddScoped<IContactUs, ContactUsService>();
            return services;
        }
    }
}
