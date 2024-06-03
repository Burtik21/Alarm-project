
using System.Net.Http.Json;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;




namespace MauiApp1.Components;
//Komponent, který generuje Frame na změnu času budíku
public class TimePickerComponent
{
    public TimePicker TimePicker { get; private set; }
    private readonly HttpClient httpClient = new HttpClient();

    //generuje Frame
    public Frame CreateTimePickerFrame()
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
        var timePickerLabel = new Label
        {
            Text = "čas",
            FontSize = 30,
            Padding = 10
        };

        TimePicker = new TimePicker
        {
            Format = "HH:mm",
            FontSize = 20
        };
        flexLayout.Children.Add(timePickerLabel);
        flexLayout.Children.Add(TimePicker);
        //Když se změní hodnota času -> pošle se na server  2 hodnoty. Hodina a minuta
        TimePicker.PropertyChanged += async (sender, e) =>
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                Console.WriteLine("vybran cas");
                TimeSpan selectedTime = TimePicker.Time;

                var cas = new { hod = selectedTime.Hours, min = selectedTime.Minutes };
                    

                await SendDataToServer(cas, ConstantsM.ConstantsM.ApiEndPointCas);
            }
        };
        
        return frame;
        
    }
    //Odesílání na server
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