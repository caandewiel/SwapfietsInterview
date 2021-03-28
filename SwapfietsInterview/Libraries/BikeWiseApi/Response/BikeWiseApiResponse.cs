using System.Net;
using System.Net.Http;

namespace Swapfiets_Bicycle_Theft.Libraries.BikeWiseApi.Response
{
    public abstract class BikeWiseApiResponse
    {
        private HttpStatusCode _statusCode;
        private HttpContent _content;

        protected BikeWiseApiResponse(HttpStatusCode statusCode, HttpContent content)
        {
            _statusCode = statusCode;
            _content = content;
        }
    }
}