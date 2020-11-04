using Edgias.Agrik.API.Interfaces;
using Edgias.Agrik.API.Models.Form;
using Edgias.Agrik.API.Models.View;
using Edgias.Agrik.ApplicationCore.Entities;
using System;

namespace Edgias.Agrik.API.ObjectMappers
{
    public class FieldMeasurementMapper : IMapper<FieldMeasurement, FieldMeasurementFormApiModel, FieldMeasurementApiModel>
    {
        public FieldMeasurement Map(FieldMeasurementFormApiModel apiModel)
        {
            FieldMeasurement entity = new FieldMeasurement
            {
                CreatedBy = apiModel.UserId
            };

            Map(entity, apiModel);

            return entity;
        }

        public FieldMeasurementApiModel Map(FieldMeasurement entity)
        {
            FieldMeasurementApiModel apiModel = new FieldMeasurementApiModel
            {
                Id = entity.Id,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.LastModifiedDate,
                IsActive = entity.IsActive,
                Name = entity.Name
            };

            return apiModel;
        }

        public void Map(FieldMeasurement entity, FieldMeasurementFormApiModel apiModel)
        {
            entity.Name = apiModel.Name;
            entity.LastModifiedBy = apiModel.UserId;
            entity.LastModifiedDate = DateTimeOffset.Now;
        }
    }
}
