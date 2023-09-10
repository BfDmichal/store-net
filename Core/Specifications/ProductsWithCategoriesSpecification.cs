using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductsWithCategoriesSpecification : BaseSpecification<Product>
    {
        public ProductsWithCategoriesSpecification(ProductSpecificationParams specParams) 
            : base(p =>
                ((string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search))) &&
                (!specParams.CategoryId.HasValue || p.ProductCategoryId == specParams.CategoryId)
            )
        {
            AddInclude(p => p.ProductCategory);
            AddOrderBy(p => p.Name);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }

        public ProductsWithCategoriesSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductCategory);
        }
    }
}
