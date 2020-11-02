using Edgias.Agrik.API.Interfaces;
using Edgias.Agrik.API.Models.Form;
using Edgias.Agrik.API.Models.View;
using Edgias.Agrik.API.ObjectMappers;
using Edgias.Agrik.ApplicationCore.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Edgias.Agrik.API.Extensions
{
    public static class ObjectMapperExtension
    {
        public static void AddObjectMappers(this IServiceCollection services)
        {
            services.AddScoped<IMapper<CropCategory, CropCategoryFormApiModel, CropCategoryApiModel>, CropCategoryMapper>();
            services.AddScoped<IMapper<CropUnit, CropUnitFormApiModel, CropUnitApiModel>, CropUnitMapper>();
            services.AddScoped<IMapper<Crop, CropFormApiModel, CropApiModel>, CropMapper>();
        }
    }
}
