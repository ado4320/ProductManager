using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.Services.Entities
{
    public class Role
    {
        [Key]
        public Guid IdRole { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
