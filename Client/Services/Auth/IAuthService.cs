using Client.Data.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IAuthService
    {
      
            Task<LoginResult> Login(LoginModel login);
            Task Logout();
       
       
    }
}
