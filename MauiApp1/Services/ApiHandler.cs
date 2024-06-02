using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using MauiApp1.ConstantsM;
using MauiApp1.Config;

namespace MauiApp1.Services;

public class ApiHandler
{
    private readonly HttpClient httpClient = new HttpClient();
    public async Task SendDataToServer (object data, string path)
    {
        try
        {
            
            string is_on = "is_on";
            var dataa = new { is_on = true };
           // var stringBuild = Config.Config.ApiBaseUrl + path;
            var response = await httpClient.PostAsJsonAsync("http://141.147.16.43/api/is_on/", dataa);
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"Data odeslána na server: {data}");
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Odpověď od serveru: " + responseBody);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Chyba při odesílání dat: {ex.Message}");
        }
    }
}