using NoisEmap.Domain.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NoisEmap.Infrastructure.Clients
{
    public class GeocodeClient : IGeocodeClient
    {
        private readonly HttpClient _httpClient;

        public GeocodeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
        {
            // Código simulado para o professor
            return (Latitude: -23.5505, Longitude: -46.6333);
        }
    }
}