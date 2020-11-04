using System;

namespace Edgias.Agrik.API.Models.Form
{
    public class WorkItemSubCategoryFormApiModel : BaseFormApiModel
    {
        public string Name { get; set; }

        public Guid WorkItemCategoryId { get; set; }
    }
}
