using Infrastructure.Clients.Interfaces;
using Infrastructure.Entities;
using System.Net.Http.Json;

namespace Infrastructure.Clients;

public class HttpCustomerClient : IHttpCustomerClient
{
    private readonly HttpClient _httpClient;

    public HttpCustomerClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CustomerHttp?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"/v1/customer/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var customer = await response.Content.ReadFromJsonAsync<CustomerHttp>(cancellationToken: cancellationToken);
        return customer;
    }
}
