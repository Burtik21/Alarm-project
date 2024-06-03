using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using MauiApp1.Models;

namespace MauiApp1.Components
{
    //Komponent, který generuje Frame na Historii budíků
    public class HistoryComponent
    {
        private readonly HttpClient httpClient = new HttpClient();
        
        //testovací data
        public Root GetTestData()
        {
            return new Root
            {
                Data = new List<DataItem>
                {
                    new DataItem { Date = "2024-06-02 01:11:04", Secs = 52 },
                    new DataItem { Date = "2024-06-02 02:22:15", Secs = 34 },
                    new DataItem { Date = "2024-06-02 03:33:26", Secs = 23 },
                    new DataItem { Date = "2024-06-02 04:44:37", Secs = 67 }
                }
            };
        }
        //Generuje UI a zároveň získává a binduje data ze serveru
        //Bohužel je to spojené v jedné metodě (ano vim není to hezké), protože byl problém to volat samostatně a vracet pouze ty data
         public async Task GetDataServer(StackLayout stackLayout)
        {
            try
            {/*
                var dateLabel = new Label
                {
                    Text = result,
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.End
                };*/
                
                var flexLayoutMain = new FlexLayout
                {
                    Direction = FlexDirection.Column,
                    JustifyContent = FlexJustify.SpaceBetween
                };

                var frame = new Frame
                {
                    CornerRadius = 20,
                    Content = flexLayoutMain,
                    BackgroundColor = Colors.DarkGray
                };
                var response = await httpClient.GetAsync(ConstantsM.ConstantsM.ApiEndPointPalarmDurationHistory);
                var responseContent = await response.Content.ReadAsStringAsync();
                
                //var serverData = JsonSerializer.Deserialize<object>(responseContent);
                //string jsonResponse = JsonSerializer.Serialize(serverData, new JsonSerializerOptions { WriteIndented = true });
                
                using JsonDocument doc = JsonDocument.Parse(responseContent);
                JsonElement root = doc.RootElement;
                JsonElement dataArray = root.GetProperty("data");
                //string result = "";
                
                //pro každou dvojici (date a čas) se vygeneruje FlexLayout do kterého se přidají hodnoty
                foreach (JsonElement item in dataArray.EnumerateArray())
                {
                    string date = item.GetProperty("date").GetString();
                    int secs = item.GetProperty("secs").GetInt32();
                    
                    var flexLayoutElement = new FlexLayout
                    {
                        Direction = FlexDirection.Row,
                        JustifyContent = FlexJustify.SpaceBetween,
                        AlignItems = FlexAlignItems.Center,
                        Margin = new Thickness(0, 10, 0, 25)
                    };

                    var timeLabel = new Label
                    {
                        Text = $"{secs} seconds",
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Start
                    };

                    var dateLabel = new Label
                    {
                        Text = $"{date} datum" ,
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.End
                    };

                    flexLayoutElement.Children.Add(dateLabel);
                    flexLayoutElement.Children.Add(timeLabel);

                    flexLayoutMain.Children.Add(flexLayoutElement);
                    
                }
                stackLayout.Children.Add(frame);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při odesílání dat: {ex.Message}");
            }
    }
    }
}
