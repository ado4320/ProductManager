using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.Services.Dtos
{
    public  class SearchFilter
    {
        public string? Name { get; set; }

        public decimal? MinimumPrice { get; set; }

        public decimal? MaximunPrice { get; set; }
    }
}
