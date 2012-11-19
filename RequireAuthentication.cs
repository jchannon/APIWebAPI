using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIWebAPI
{
    public class RequireAuthentication : DelegatingHandler
    {
        private readonly IUserApiMapper userApiMapper;

        public RequireAuthentication(IUserApiMapper userApiMapper)
        {
            this.userApiMapper = userApiMapper;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization != null && request.Headers.Authorization.Scheme == "Bearer")
            {
                if (userApiMapper.UserAuthorizedFromAccessToken(request.Headers.Authorization.Parameter))
                {
                    return base.SendAsync(request, cancellationToken);
                }
            }

            return FobiddenResponse();
        }

        public Task<HttpResponseMessage> FobiddenResponse()
        {
            return Task<HttpResponseMessage>.Factory.StartNew(
                () =>
                new HttpResponseMessage(HttpStatusCode.Forbidden));
        }
    }
}