using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;

namespace Token
{
    public class WebApiRequest
    {
        public static HttpClient GetHttpClient(IPrincipal userPrincipal, string urlRequest)
        {
            var client = new HttpClient { BaseAddress = new Uri(urlRequest) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (userPrincipal != null && userPrincipal.Identity != null)
            {
                var claims = ((ClaimsIdentity)userPrincipal.Identity).Claims.ToList().FirstOrDefault(x => x.Type == "Token");
                if (claims != null)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "bearer " + claims.Value);
                }
            }

            return client;
        }
    }
}
