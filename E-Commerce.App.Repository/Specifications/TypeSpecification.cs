using E_Commerce.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.App.Repository.Specifications
{
    public class TypeSpecification : BaseSpecification<Product, string>
    {
        public TypeSpecification()
        {
            AddSelect(x => x.Type);

            ApplyDistinct();
        }
    }
}
