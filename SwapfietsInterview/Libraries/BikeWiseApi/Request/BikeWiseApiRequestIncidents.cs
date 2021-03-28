using System.Net.Http;
using System.Net.Http.Headers;
using SwapfietsInterview.Models;

namespace SwapfietsInterview.Libraries.BikeWiseApi.Request
{
    public class BikeWiseApiRequestIncidents : BikeWiseApiRequest
    {
        private const string Endpoint = "/v2/incidents";
        private const string MediaType = "application/json";

        private const string FieldProximity = "proximity";
        private const string FieldProximitySquare = "proximity_square";
        private const string FieldIncidentType = "incident_type";

        private const string IncidentTypeTheft = "theft";

        private readonly Location _location;

        public BikeWiseApiRequestIncidents(Location location)
        {
            _location = location;
        }

        private string GenerateQueryString()
        {
            var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
            
            query.Add(FieldProximity, $"{_location.Latitude},{_location.Longitude}");
            query.Add(FieldProximitySquare, _location.ProximitySize.ToString());
            query.Add(FieldIncidentType, IncidentTypeTheft);

            return "?" + query;
        }

        public override string DetermineEndpoint()
        {
            return BaseUrl + Endpoint + GenerateQueryString();
        }

        public override MediaTypeWithQualityHeaderValue DetermineContentType()
        {
            return new(MediaType);
        }

        public override HttpMethod DetermineMethod()
        {
            return HttpMethod.Get;
        }
    }
}