namespace SwapfietsInterview.Models
{
    public enum IncidentType
    {
        Theft, Crash, Hazard, Unconfirmed, InfrastructureIssue, ChopShop
    }

    public class Incident
    {
        private IncidentType IncidentType { get; }

        private float Latitude { get; }

        private float Longitude { get; }

        public Incident(IncidentType incidentType, float latitude, float longitude)
        {
            this.IncidentType = incidentType;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}