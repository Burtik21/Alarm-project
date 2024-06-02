using System.Net.Http.Json;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

using MauiApp1.Builders;
using MauiApp1.Services;
using MauiApp1.Config;
using MauiApp1.ConstantsM;

namespace MauiApp1.Components;

public class SwitchComponent
{
    public Switch ToggleSwitch { get; private set; }
    private readonly HttpClient httpClient = new HttpClient();
    


    public Frame CreateSwitchFrame()
    {
        
        var flexLayout = new FlexLayout
        {
            Direction = FlexDirection.Row,
            JustifyContent = FlexJustify.SpaceBetween,
            
        };
        
        var frame = new Frame
        {
            CornerRadius = 20,
            Content = flexLayout,
            BackgroundColor = Colors.DarkGray
        };
        
        var switchLabel = new Label
        {
            Text = "Zapnout:",
            FontSize = 30,
            Padding = 10,
            VerticalOptions = LayoutOptions.Center
        };

        ToggleSwitch = new Switch
        {
            WidthRequest = 60,
            HeightRequest = 40,
            VerticalOptions = LayoutOptions.Center
        };
        flexLayout.Children.Add(switchLabel);
        flexLayout.Children.Add(ToggleSwitch);
        ToggleSwitch.Toggled += async (sender, e) =>
        {
            Console.WriteLine("zapnuto/vypnuto");
            bool switchValue = e.Value;

            var on_off = new { is_on = switchValue };

            await SendDataToServer(on_off, ConstantsM.ConstantsM.ApiEndPointIsOn);
        };
        return frame;
    }
    public async Task SendDataToServer (object data, string path)
    {
        try
        {
            
            var response = await httpClient.PostAsJsonAsync(path, data);
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
