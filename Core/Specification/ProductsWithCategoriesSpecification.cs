using Core.Entities;
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
        public ProductsWithCategoriesSpecification()
        {
            AddInclude(p => p.ProductCategory);
        }

        public ProductsWithCategoriesSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductCategory);
        }
    }
}
