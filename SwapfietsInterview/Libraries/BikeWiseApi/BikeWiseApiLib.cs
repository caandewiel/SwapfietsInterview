
using System;
using System.Linq;
using System.Net.Http;
using Swapfiets_Bicycle_Theft.Libraries.BikeWiseApi.Response;
using SwapfietsInterview.Libraries.BikeWiseApi.Request;
using SwapfietsInterview.Libraries.BikeWiseApi.Response;

namespace SwapfietsInterview.Libraries.BikeWiseApi
{
    public static class BikeWiseApiLib
    {
        private const string HeaderTotal = "total";
        
        public static BikeWiseApiResponse ExecuteRequest(BikeWiseApiRequest request)
        {
            var client = new HttpClient {BaseAddress = request.DetermineBaseUri()};
            client.DefaultRequestHeaders.Accept.Add(request.DetermineContentType());

            var responseMessage = client.GetAsync(request.DetermineEndpoint()).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                return new BikeWiseApiResponseIncidents(
                    responseMessage.StatusCode,
                    responseMessage.Content,
                    int.Parse(responseMessage.Headers.GetValues(HeaderTotal).First())
                );
            }

            return new BikeWiseApiResponseError(responseMessage.StatusCode, responseMessage.Content);
        }
    }
}