using System;
using System.Collections.Generic;
using System.Text;

namespace Edgias.Agrik.ApplicationCore.Entities
{
    public class CropProduction : BaseEntity
    {
        public string Name { get; set; }

        public Guid CropId { get; set; }

        public Crop Crop { get; set; }
    }
}
