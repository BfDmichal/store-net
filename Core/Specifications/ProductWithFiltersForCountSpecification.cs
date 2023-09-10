using Core.Entities;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationParams specParams)
            : base(p =>
                ((string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search))) &&
                (!specParams.CategoryId.HasValue || p.ProductCategoryId == specParams.CategoryId)
            )
        {
        }
    }
}
