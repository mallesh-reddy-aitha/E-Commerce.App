using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Commerce.App.Repository.Specifications
{
    public class ProductSpecificationParameters
    {
        private const int MaxPageSize = 50;
        private List<string> _brands;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public List<string> Brands
        {
            get => _brands;
            set
            {
                _brands = value.SelectMany(x => x.Split(",",
                    StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }

        private List<string> _types;

        public List<string> Types
        {
            get => _types;
            set
            {
                _types = value.SelectMany(x => x.Split(",",
                    StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }

        private string _search;

        public string Search
        {
            get => _search ?? "";
            set
            {
                _search = value.ToLower();
            }
        }

        public string Sort { get; set; }
    }
}
