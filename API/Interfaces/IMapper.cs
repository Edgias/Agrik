﻿namespace Edgias.Agrik.API.Interfaces
{
    public interface IMapper<TEntity, TFormApiModel, TApiModel>
    {
        TEntity Map(TFormApiModel apiModel);

        TApiModel Map(TEntity entity);

        void Map(TEntity entity, TFormApiModel apiModel);
    }
}

