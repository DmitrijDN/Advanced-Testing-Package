
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AdvancedTestingPackage.Infrastructure
{
    public class UserIdentity: ClaimsIdentity
    {
        private static readonly string[] _requiredClaims =
        {
            ClaimTypes.NameIdentifier,
            ClaimTypes.Name,
            ClaimTypes.Email,
            ClaimTypes.Role
        };

        public UserCredential UserCredential
        {
            get
            {
                var credentials = new UserCredential
                {
                    Name = GetClaim(ClaimTypes.Name),
                    Email = GetClaim(ClaimTypes.Email),
                    Id = int.Parse(GetClaim(ClaimTypes.NameIdentifier)),
                    Role = GetClaim(ClaimTypes.Role)
                };

                return credentials;
            }
        }

        public static string[] RequiredClaims
        {
            get { return _requiredClaims; }
        }

        public UserIdentity(IEnumerable<Claim> claims, string type) : base(claims, type) { }

        public static UserIdentity Current
        {
            get
            {
                var authManager = HttpContext.Current.GetOwinContext().Authentication;
                var logged =
                    authManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ApplicationCookie).Result;
                return logged != null
                    ? new UserIdentity(logged.Claims, DefaultAuthenticationTypes.ApplicationCookie)
                    : null;
            }
        }

        private string GetClaim(string claimType)
        {
            var claim = Claims.FirstOrDefault(c => c.Type == claimType);
            var data = (claim != null) ? claim.Value : String.Empty;
            return data;
        }
    }

    public class UserClaims
    {
        public const string FIRST_NAME = "First name";
        public const string LAST_NAME = "Last Name";
        public const string MIDDLE_NAME = "Middle Name";
        public const string EMAIL = "Email";
        public const string PASSWORD = "Password";
        public const string ID = "Id";


        //public const string NAME = @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        //public const string EMAIL = @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        //public const string ID = @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        //public const string ROLE = "User Role";
    }
}