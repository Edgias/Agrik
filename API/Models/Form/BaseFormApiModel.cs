using System;

namespace Edgias.Agrik.API.Models.Form
{
    public abstract class BaseFormApiModel
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

    }
}
