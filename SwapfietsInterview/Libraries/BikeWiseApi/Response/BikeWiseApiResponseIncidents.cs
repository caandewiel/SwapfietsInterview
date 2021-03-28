using System.Net;
using System.Net.Http;
using Swapfiets_Bicycle_Theft.Libraries.BikeWiseApi.Response;

namespace SwapfietsInterview.Libraries.BikeWiseApi.Response
{
    public class BikeWiseApiResponseIncidents : BikeWiseApiResponse
    {
        public int NumberOfResults { get; }
        
        public BikeWiseApiResponseIncidents(HttpStatusCode statusCode, HttpContent content, int numberOfResults) : base(statusCode, content)
        {
            NumberOfResults = numberOfResults;
        }
    }
}