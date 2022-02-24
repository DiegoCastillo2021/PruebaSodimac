using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Token.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {/*
            return Task.Factory.StartNew(() =>
            {
                var claims = new List<Claim>();

                new Claim(ClaimTypes.);


            };*/


            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            /*
            using (TestContext db = new TestContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Login == context.UserName && u.Password == context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }*/

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            /*
            foreach (var item in context.Scope)
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, item));
                identity.AddClaim(new Claim(ClaimTypes.Hash, item));
                identity.AddClaim(new Claim(ClaimTypes.Role, item));
            }
            */
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            context.Validated(identity);
        }
    }
}
