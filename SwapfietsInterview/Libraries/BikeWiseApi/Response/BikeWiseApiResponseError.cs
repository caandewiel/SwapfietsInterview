using System.Net;
using System.Net.Http;

namespace Swapfiets_Bicycle_Theft.Libraries.BikeWiseApi.Response
{
    public class BikeWiseApiResponseError : BikeWiseApiResponse
    {
        public BikeWiseApiResponseError(HttpStatusCode statusCode, HttpContent content) : base(statusCode, content)
        {
        }
    }
}