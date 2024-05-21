using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.Services.Entities
{
    public class User
    {
        public string Id { get; set; }= null!;
        [ForeignKey("Role")]
        public Guid IdRol { get; set; }
        public string? Password { get; set; }
        public Role? Role { get; set; }
    }
}
