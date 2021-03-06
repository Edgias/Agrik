﻿using Edgias.Agrik.API.Interfaces;
using Edgias.Agrik.API.Models.Form;
using Edgias.Agrik.API.Models.View;
using Edgias.Agrik.ApplicationCore.Entities;
using System;

namespace Edgias.Agrik.API.ObjectMappers
{
    public class LocationMapper : IMapper<Location, LocationFormApiModel, LocationApiModel>
    {
        public Location Map(LocationFormApiModel apiModel)
        {
            Location entity = new Location
            {
                CreatedBy = apiModel.UserId
            };

            Map(entity, apiModel);

            return entity;
        }

        public LocationApiModel Map(Location entity)
        {
            LocationApiModel apiModel = new LocationApiModel
            {
                Id = entity.Id,
                IsActive = entity.IsActive,
                City = entity.City,
                Country = entity.Country,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.LastModifiedDate,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                Name = entity.Name,
                State = entity.State,
                Street1 = entity.Street1,
                Street2 = entity.Street2,
                ZipCode = entity.ZipCode
            };

            return apiModel;
        }

        public void Map(Location entity, LocationFormApiModel apiModel)
        {
            entity.Name = apiModel.Name;
            entity.Street1 = apiModel.Street1;
            entity.Street2 = apiModel.Street2;
            entity.City = apiModel.City;
            entity.State = apiModel.State;
            entity.ZipCode = apiModel.ZipCode;
            entity.Latitude = apiModel.Latitude;
            entity.Longitude = apiModel.Longitude;
            entity.LastModifiedBy = apiModel.UserId;
            entity.LastModifiedDate = DateTimeOffset.Now;
        }
    }
}
