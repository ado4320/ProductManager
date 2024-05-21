using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.Services.Entities
{
    public class Product
    {
        
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }   
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public Category? Category { get; set; }
    }
}
