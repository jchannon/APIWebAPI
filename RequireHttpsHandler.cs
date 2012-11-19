using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIWebAPI
{
    public class RequireHttpsHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                return Task<HttpResponseMessage>.Factory.StartNew(
                    () => new HttpResponseMessage(HttpStatusCode.Forbidden));
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}