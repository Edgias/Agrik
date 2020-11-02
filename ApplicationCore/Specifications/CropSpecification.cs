using Edgias.Agrik.ApplicationCore.Entities;

namespace Edgias.Agrik.ApplicationCore.Specifications
{
    public class CropSpecification : BaseSpecification<Crop>
    {
        public CropSpecification(string searchQuery)
            : base(c => string.IsNullOrEmpty(searchQuery) || c.Name.Contains(searchQuery))
        {
        }

        public CropSpecification(int skip, int take, string searchQuery) 
            : base(c => string.IsNullOrEmpty(searchQuery) || c.Name.Contains(searchQuery))
        {
            ApplyOrderBy(c => c.Name);
            ApplyPaging(skip, take);
        }
    }
}
