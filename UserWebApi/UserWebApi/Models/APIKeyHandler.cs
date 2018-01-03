using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace UserWebApi.Models
{
    public class APIKeyHandler: DelegatingHandler
    {
        private const string APIKeyToCheck = "sandeep123";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> requestHeaders;
            var checkApiKeyExists = request.Headers.TryGetValues("APIKey", out requestHeaders);
            if (checkApiKeyExists)
            {
                validKey = requestHeaders.FirstOrDefault().Equals(APIKeyToCheck);
            }
            if (!validKey)
                return request.CreateResponse(HttpStatusCode.Forbidden, "Invalid API key");

            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}