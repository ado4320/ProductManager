using Microsoft.EntityFrameworkCore;
using ProductManager.Core.Services.Entities;
using ProductManager.Core.Services.Interfaces.Repositories;
using ProductManager.Infrastructure.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastructure.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public BaseContext Context { get; }

        public AuthRepository(BaseContext dbContext)
        {
            Context = dbContext;
        }

        public User? ValidationUser(User user)
        {
            var existingUser = Context.Users.Include(x => x.Role)
            .SingleOrDefault(x => x.Id == user.Id && x.Password == user.Password);

            return existingUser;
        }
    }
}
