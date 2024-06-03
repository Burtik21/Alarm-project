using System.Net.Http.Json;

using System.Text.Json;
using MauiApp1.Components;

using Microsoft.Maui.Layouts;

namespace MauiApp1;

/* Bohužel zde vytvářím celou komponentu Historie, důvod -> Maui dělalo velké problémy to mít v samostatné třídě, nevím proč
 * To stejné i s ApiHandlerem -> musel jsem vytvářet ty metody přímo ve třídách, protože se Maui nelíbilo mít na to samostatnou třídu, to stejné i s FrameGeneratorem
 * 

 */



public partial class MainPage : ContentPage
{
    private TimePickerComponent timePickerComponent;
    private SwitchComponent switchComponent;
    private HistoryComponent historyComponent;
    private VolumeComponent volumeComponent;
    private readonly HttpClient httpClient = new HttpClient();
    
    public MainPage()
    {
        InitializeComponent();
        CreateUI();
    }

    private void CreateUI()
    {
        
        var stackLayout = new StackLayout
        {
            BackgroundColor = Colors.WhiteSmoke,
            Padding = 20,
            Spacing = 20
        };
        
        //vytvarim componenty(framy) a následně vkládám do Stack Layoutu
        timePickerComponent = new TimePickerComponent();
        var timePickerFrame = timePickerComponent.CreateTimePickerFrame();

        switchComponent = new SwitchComponent();
        var switchFrame = switchComponent.CreateSwitchFrame();

        volumeComponent = new VolumeComponent();
        var volumeFrame = volumeComponent.CreateVolumeFrame();

        stackLayout.Children.Add(timePickerFrame);
        stackLayout.Children.Add(switchFrame);
        
        //stackLayout.Children.Add(historyFrame);
        GetDataServer(stackLayout);
        stackLayout.Children.Add(volumeFrame);
        Content = stackLayout;
        Console.WriteLine("vytvoreno UI");
    }
    //Celá třída HistoryComponent
    private async Task GetDataServer(StackLayout stackLayout)
        {
            try
            {
                var flexLayoutMain = new FlexLayout
                {
                    Direction = FlexDirection.Column,
                    JustifyContent = FlexJustify.SpaceBetween
                };

                var frame = new Frame
                {
                    CornerRadius = 20,
                    Content = flexLayoutMain
                };
                var response = await httpClient.GetAsync(ConstantsM.ConstantsM.ApiEndPointPalarmDurationHistory);
                var responseContent = await response.Content.ReadAsStringAsync();
                
                //var serverData = JsonSerializer.Deserialize<object>(responseContent);
                //string jsonResponse = JsonSerializer.Serialize(serverData, new JsonSerializerOptions { WriteIndented = true });
                
                using JsonDocument doc = JsonDocument.Parse(responseContent);
                JsonElement root = doc.RootElement;
                JsonElement dataArray = root.GetProperty("data");
                string result = "";
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