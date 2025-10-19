namespace NoisEmap.Domain.Interfaces
{
    public interface IGeocodeClient
    {
        Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address);
    }
}