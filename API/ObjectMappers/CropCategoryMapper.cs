using Edgias.Agrik.API.Interfaces;
using Edgias.Agrik.API.Models.Form;
using Edgias.Agrik.API.Models.View;
using Edgias.Agrik.ApplicationCore.Entities;
using System;

namespace Edgias.Agrik.API.ObjectMappers
{
    public class CropCategoryMapper : IMapper<CropCategory, CropCategoryFormApiModel, CropCategoryApiModel>
    {
        public CropCategory Map(CropCategoryFormApiModel apiModel)
        {
            CropCategory entity = new CropCategory
            {
                CreatedBy = apiModel.UserId
            };

            Map(entity, apiModel);

            return entity;
        }

        public CropCategoryApiModel Map(CropCategory entity)
        {
            CropCategoryApiModel apiModel = new CropCategoryApiModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.LastModifiedDate,
                IsActive = entity.IsActive
            };

            return apiModel;
        }

        public void Map(CropCategory entity, CropCategoryFormApiModel apiModel)
        {
            entity.Name = apiModel.Name;
            entity.Description = apiModel.Description;
            entity.LastModifiedBy = apiModel.UserId;
            entity.LastModifiedDate = DateTimeOffset.Now;
        }
    }
}
