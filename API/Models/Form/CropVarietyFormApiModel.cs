using System;

namespace Edgias.Agrik.API.Models.Form
{
    public class CropVarietyFormApiModel : BaseFormApiModel
    {
        public string Name { get; set; }

        public Guid CropId { get; set; }
    }
}
