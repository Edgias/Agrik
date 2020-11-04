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
            services.AddScoped<IMapper<CropVariety, CropVarietyFormApiModel, CropVarietyApiModel>, CropVarietyMapper>();
            services.AddScoped<IMapper<Field, FieldFormApiModel, FieldApiModel>, FieldMapper>();
            services.AddScoped<IMapper<FieldMeasurement, FieldMeasurementFormApiModel, FieldMeasurementApiModel>, FieldMeasurementMapper>();
            services.AddScoped<IMapper<Location, LocationFormApiModel, LocationApiModel>, LocationMapper>();
            services.AddScoped<IMapper<OwnershipType, OwnershipTypeFormApiModel, OwnershipTypeApiModel>, OwnershipTypeMapper>();
            services.AddScoped<IMapper<SeasonStatus, SeasonStatusFormApiModel, SeasonStatusApiModel>, SeasonStatusMapper>();
            services.AddScoped<IMapper<Season, SeasonFormApiModel, SeasonApiModel>, SeasonMapper>();
            services.AddScoped<IMapper<SoilType, SoilTypeFormApiModel, SoilTypeApiModel>, SoilTypeMapper>();
            services.AddScoped<IMapper<WorkItemCategory, WorkItemCategoryFormApiModel, WorkItemCategoryApiModel>, WorkItemCategoryMapper>();
            services.AddScoped<IMapper<WorkItemSubCategory, WorkItemSubCategoryFormApiModel, WorkItemSubCategoryApiModel>, WorkItemSubCategoryMapper>();
            services.AddScoped<IMapper<WorkItemStatus, WorkItemStatusFormApiModel, WorkItemStatusApiModel>, WorkItemStatusMapper>();
            services.AddScoped<IMapper<WorkItem, WorkItemFormApiModel, WorkItemApiModel>, WorkItemMapper>();
        }
    }
}
