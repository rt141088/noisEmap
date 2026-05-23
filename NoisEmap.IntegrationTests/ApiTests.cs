using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_TestEndpoint_DeveRetornarOK()
    {
        var response = await _client.GetAsync("/api/test");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Post_Sensor_Valido_DeveRetornarOK()
    {
        var json = "{\"temperatura\":25,\"umidade\":60}";
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/test/sensor", content);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Post_Sensor_Invalido_DeveRetornarErro()
    {
        var json = "{\"temperatura\":200,\"umidade\":60}";
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/test/sensor", content);

        Assert.False(response.IsSuccessStatusCode);
    }
}
