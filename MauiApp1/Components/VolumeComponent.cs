using System.Net.Http.Json;
using Microsoft.Maui.Layouts;

namespace MauiApp1.Components;

public class VolumeComponent
{
    public Slider PercentSlider { get; private set; }
    private Label percentLabel;
    
    private readonly HttpClient httpClient = new HttpClient();
    

    

   
        
    

    
    public Frame CreateVolumeFrame()
    {
        
        var flexLayout = new FlexLayout
        {
            Direction = FlexDirection.Row,
            JustifyContent = FlexJustify.SpaceBetween
        };
        
        var frame = new Frame
        {
            CornerRadius = 20,
            Content = flexLayout,
            BackgroundColor = Colors.DarkGray
        };
        PercentSlider = new Slider
        {
            Minimum = 0,
            Maximum = 100,
            Value = 0,
            HeightRequest = 50, 
            WidthRequest = 150, 
            ThumbColor = Colors.RosyBrown, 
            MinimumTrackColor = Colors.White, 
            MaximumTrackColor = Colors.Black
            
        };

        percentLabel = new Label
        {
            Text = "Hlasitost",
            FontSize = 30,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.End
        };
        
        
        flexLayout.Children.Add(percentLabel);
        flexLayout.Children.Add(PercentSlider);
        PercentSlider.ValueChanged += async (sender, e) =>
        {
            int percent = ((int)Math.Round(e.NewValue))*10;
            var alarm_volume = new { volume = percent };
            await SendDataToServer(alarm_volume, ConstantsM.ConstantsM.ApiEndPointVolume);

        };
        return frame;
        
    }

    public void UpdateProgress(double percent)
    {
        PercentSlider.Value = percent;
    }
    
    
    public async Task SendDataToServer(object data, string path)
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
