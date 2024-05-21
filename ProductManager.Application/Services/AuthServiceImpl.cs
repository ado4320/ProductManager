using ProductManager.Core.Services.Entities;
using ProductManager.Core.Services.Interfaces.Repositories;
using ProductManager.Core.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Services
{
    public class AuthServiceImpl : IAuthService
    {
        private IAuthRepository _authRepository { get; }

        public AuthServiceImpl(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public User? ValidationUser(User user)
        {
            return _authRepository.ValidationUser(user);
        }
    }
}
