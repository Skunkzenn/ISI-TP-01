using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ApiVendasService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl = "https://localhost:44369/api/vendas";

    public ApiVendasService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ConsolaVendaDTO>> GetVendasAsync(string consola, DateTime inicio, DateTime fim)
    {
        var inicioString = inicio.ToString("yyyy-MM-dd");
        var fimString = fim.ToString("yyyy-MM-dd");
        var url = $"{_apiBaseUrl}/{consola}/periodo?inicio={inicioString}&fim={fimString}";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ConsolaVendaDTO>>(jsonResponse);
        }

        return null;
    }
}
