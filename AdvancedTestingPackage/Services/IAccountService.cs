
using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedTestingPackage.Models;
using DataAccess.Entities;
using IdentitySample.Models;
using Microsoft.Owin.Security;

namespace AdvancedTestingPackage.Services
{
    public interface IAccountService
    {
        Task<RegisterResultViewModel> Register(User user, int roleId);
        Task<RegisterResultViewModel> LoginCallback(LoginViewModel model); 
        void SignIn(LoginViewModel model, User userInfo);
        void SignOut();
        System.Security.Claims.ClaimsAuthenticationManager ClaimsAuthenticationManager { get; }
        IAuthenticationManager AuthenticationManager { get; }
        List<Role> GetUserRoles();
    }
}
