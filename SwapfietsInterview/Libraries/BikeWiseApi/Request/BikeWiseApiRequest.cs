using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SwapfietsInterview.Libraries.BikeWiseApi.Request
{
    public abstract class BikeWiseApiRequest
    {
        protected const string BaseUrl = "https://bikewise.org/api";

        public Uri DetermineBaseUri()
        {
            return new(BaseUrl);
        }

        public abstract string DetermineEndpoint();

        public abstract MediaTypeWithQualityHeaderValue DetermineContentType();

        public abstract HttpMethod DetermineMethod();
    }
}