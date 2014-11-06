
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AdvancedTestingPackage.Models;
using DataAccess.Entities;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.IdentityModel.Services;
using Claim = System.Security.Claims.Claim;
using ClaimTypes = System.Security.Claims.ClaimTypes;

namespace AdvancedTestingPackage.Services
{
    public class AccountService: IAccountService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AccountService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<RegisterResultViewModel> Register(User user, int roleId)
        {
            RegisterResultViewModel result = new RegisterResultViewModel();
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var userRepository = unitOfWork.GetTypedRepository<IUserRepository>();
                var roleRepository = unitOfWork.GetTypedRepository<IRoleRepository>();
                user.Role = roleRepository.Get(r => r.Id == roleId).FirstOrDefault();
                if (userRepository.Get(u => u.Email.ToLower() == user.Email.ToLower()).FirstOrDefault() == null)
                {
                    userRepository.AddItem(user);
                    result.Succeed = true;
                }
                else
                {
                    result.Succeed = false;
                    result.Errors.Add("User with current email is already exist");
                }
            }
            return result;
        }

        public async Task<RegisterResultViewModel> LoginCallback(LoginViewModel model)
        {
            RegisterResultViewModel result = new RegisterResultViewModel();
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var userRepository = unitOfWork.GetTypedRepository<IUserRepository>();
                var user =
                    userRepository.Get(u => u.Email.ToLower() == model.Email.ToLower() && u.Password == model.Password)
                        .FirstOrDefault();
                if (user != null)
                {
                    SignIn(model, user);
                    result.Succeed = true;
                }
                else
                {
                    result.Succeed = false;
                    result.Errors.Add("Email or password is incorrect");
                }
            }
            return result;
        }

        public List<Role> GetUserRoles()
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var rolesRepository = unitOfWork.GetTypedRepository<IRoleRepository>();
                var roles = rolesRepository.GetAll().ToList();
                return roles;
            }
        } 

        public void SignIn(LoginViewModel model, User userInfo)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userInfo.Name.FirstName + " " + userInfo.Name.LastName),
                new Claim(ClaimTypes.Email, userInfo.Email),
                new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
                new Claim(@"http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                    userInfo.Email),
                new Claim(@"http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identity",
                    userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.Role.RoleName)
            };
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties {IsPersistent = true}, identity);
        }

        public void SignOut()
        {
            AuthenticationManager.SignOut();
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public ClaimsAuthenticationManager ClaimsAuthenticationManager
        {
            get
            {
                return FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager;
            }
        }
    }
}