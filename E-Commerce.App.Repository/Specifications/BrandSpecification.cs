using E_Commerce.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.App.Repository.Specifications
{
    public class BrandSpecification : BaseSpecification<Product, string>
    {
        public BrandSpecification()
        {
            AddSelect(x => x.Brand);

            ApplyDistinct();
        }
    }
}
