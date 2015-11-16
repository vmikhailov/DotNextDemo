using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DotNextRZD.PublicApi.Handlers
{
    /// <summary>
    ///     The purpose of this class is to intercept response and replace NULL with proper status HttpStatusCode
    /// </summary>
    public class NullJsonHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (response.Content == null)
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                }
                else
                {
                    var objectContent = response.Content as ObjectContent;
                    if (objectContent != null && objectContent.Value == null)
                    {
                        response.StatusCode = HttpStatusCode.NoContent;
                    }
                }
            }
            return response;
        }
    }
}