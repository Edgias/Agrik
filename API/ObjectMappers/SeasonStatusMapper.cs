using Edgias.Agrik.API.Interfaces;
using Edgias.Agrik.API.Models.Form;
using Edgias.Agrik.API.Models.View;
using Edgias.Agrik.ApplicationCore.Entities;
using System;

namespace Edgias.Agrik.API.ObjectMappers
{
    public class SeasonStatusMapper : IMapper<SeasonStatus, SeasonStatusFormApiModel, SeasonStatusApiModel>
    {
        public SeasonStatus Map(SeasonStatusFormApiModel apiModel)
        {
            SeasonStatus entity = new SeasonStatus
            {
                CreatedBy = apiModel.UserId
            };

            Map(entity, apiModel);

            return entity;
        }

        public SeasonStatusApiModel Map(SeasonStatus entity)
        {
            SeasonStatusApiModel apiModel = new SeasonStatusApiModel
            {
                IsDefault = entity.IsDefault,
                Id = entity.Id,
                IsActive = entity.IsActive,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.LastModifiedDate,
                Name = entity.Name
            };

            return apiModel;
        }

        public void Map(SeasonStatus entity, SeasonStatusFormApiModel apiModel)
        {
            entity.Name = apiModel.Name;
            entity.IsDefault = apiModel.IsDefault;
            entity.LastModifiedBy = apiModel.UserId;
            entity.LastModifiedDate = DateTimeOffset.Now;
        }
    }
}
