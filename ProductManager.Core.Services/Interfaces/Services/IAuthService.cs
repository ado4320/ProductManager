using ProductManager.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.Services.Interfaces.Services
{
    public interface IAuthService
    {
        User? ValidationUser(User user);
    }
}
