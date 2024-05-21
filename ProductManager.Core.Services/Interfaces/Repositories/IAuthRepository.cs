using ProductManager.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.Services.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        User? ValidationUser(User user);
    }
}
