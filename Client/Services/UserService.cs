using Client.Data.Model;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
    public class UserService
    {
        private readonly DB appDBContext;
        private readonly AuthenticationStateProvider apiAuthenticationStateProvider;
        public UserService(DB appDBContext, AuthenticationStateProvider apiAuthenticationStateProvider)
        {
            this.appDBContext = appDBContext;
            this.apiAuthenticationStateProvider = apiAuthenticationStateProvider;

        }
        public async Task<int> GetUserId()
        {
            var state = await apiAuthenticationStateProvider.GetAuthenticationStateAsync();

            return int.Parse(state.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
        }

        public async Task<bool> HasRole(string roleName)
        {
            var state = await apiAuthenticationStateProvider.GetAuthenticationStateAsync();
            return state.User.Claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                            .FirstOrDefault(c => c.Value == roleName) != null;

        }



    }
}
