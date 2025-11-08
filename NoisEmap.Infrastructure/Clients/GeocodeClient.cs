using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NoisEmap.Domain.Interfaces; // ✅ CORRETO: vem do Domain, não do Application

namespace NoisEmap.Infrastructure.Clients
{
    public class GeocodeClient : IGeocodeClient
    {
        private readonly HttpClient _httpClient;

        public GeocodeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Implementação do método exigido pela interface IGeocodeClient
        public async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
        {
            try
            {
                // Exemplo simples de delay (simulando chamada de API real)
                await Task.Delay(100);

                // 🔧 Aqui você implementa a chamada real à API de geocodificação
                // var response = await _httpClient.GetAsync($"geocode?address={Uri.EscapeDataString(address)}");
                // response.EnsureSuccessStatusCode();
                // var json = await response.Content.ReadAsStringAsync();
                // var data = JsonDocument.Parse(json);
                // double lat = data.RootElement.GetProperty("lat").GetDouble();
                // double lon = data.RootElement.GetProperty("lon").GetDouble();
                // return (lat, lon);

                // Mock temporário
                return (-23.5505, -46.6333); // São Paulo como exemplo
            }
            catch
            {
                // Em caso de erro, retorna 0,0 — você pode logar ou lançar exceção aqui
                return (0, 0);
            }
        }
    }
}
