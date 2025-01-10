using E_Commerce.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Commerce.App.Repository.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecificationParameters productSpecificationParameters) : base(x =>
        (string.IsNullOrEmpty(productSpecificationParameters.Search) || x.Name.ToLower().Contains(productSpecificationParameters.Search)) &&
                  ((productSpecificationParameters.Brands == null || productSpecificationParameters.Brands.Count == 0) ||
        productSpecificationParameters.Brands.Contains(x.Brand)) &&
                  ((productSpecificationParameters.Types == null || productSpecificationParameters.Types.Count == 0) ||
        productSpecificationParameters.Types.Contains(x.Type))
        )
        {
            ApplyPaging(productSpecificationParameters.PageSize * (productSpecificationParameters.PageIndex - 1),
                productSpecificationParameters.PageIndex);
            switch (productSpecificationParameters.Sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
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
