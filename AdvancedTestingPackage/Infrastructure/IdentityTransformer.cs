
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace AdvancedTestingPackage.Infrastructure
{
    public class IdentityTransformer : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            var identity = incomingPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
            {
                throw new AuthenticationException();
            }

            return CreatePrincipal(identity);
        }

        private ClaimsPrincipal CreatePrincipal(ClaimsIdentity identity)
        {
            var userEmail = identity.FindFirst(ClaimTypes.Email);
            var userName = identity.FindFirst(ClaimTypes.Name); 

            var newClaims = UserIdentity.RequiredClaims.Select(identity.FindFirst).Where(c => c != null).ToList();
            if (userEmail != null)
            {
                newClaims.Add(userEmail);
            }
            if (userName != null)
            {
                newClaims.Add(userName);
            }

            var azIdentity = new UserIdentity(newClaims,
                                        DefaultAuthenticationTypes.ApplicationCookie);

            return new ClaimsPrincipal(azIdentity);
        }
    }
}