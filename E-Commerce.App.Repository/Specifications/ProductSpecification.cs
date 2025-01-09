using E_Commerce.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.App.Repository.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(string brand = null, string type = null, string sort = null) : base(x =>
                  (string.IsNullOrEmpty(brand) || x.Brand == brand) &&
                  (string.IsNullOrEmpty(type) || x.Type == type)
        )
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(x=>x.Price);
                    break;

                case "priceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;

                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }
    }
}
