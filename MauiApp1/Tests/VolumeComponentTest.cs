using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MauiApp1.Components;
using Microsoft.Maui.Controls;
using Xunit;
using Moq;

namespace MauiApp1.Tests
{
    public class VolumeComponentTests
    {
        [Fact]
        public void CreateVolumeFrame_ShouldCreateFrameWithComponents()
        {
            // Arrange
            var volumeComponent = new VolumeComponent();

            // Act
            var frame = volumeComponent.CreateVolumeFrame();

            // Assert
            Assert.NotNull(frame);
            Assert.NotNull(frame.Content);
            Assert.IsType<FlexLayout>(frame.Content);

            var flexLayout = (FlexLayout)frame.Content;
            Assert.Equal(2, flexLayout.Children.Count);
            Assert.IsType<Label>(flexLayout.Children[0]);
            Assert.IsType<Slider>(flexLayout.Children[1]);
        }

        [Fact]
        public void PercentSlider_ShouldHaveCorrectProperties()
        {
            // Arrange
            var volumeComponent = new VolumeComponent();
            var frame = volumeComponent.CreateVolumeFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var slider = (Slider)flexLayout.Children[1];

            // Assert
            Assert.Equal(0, slider.Minimum);
            Assert.Equal(100, slider.Maximum);
            Assert.Equal(0, slider.Value);
            Assert.Equal(50, slider.HeightRequest);
            Assert.Equal(150, slider.WidthRequest);
            Assert.Equal(Colors.RosyBrown, slider.ThumbColor);
            Assert.Equal(Colors.White, slider.MinimumTrackColor);
            Assert.Equal(Colors.Black, slider.MaximumTrackColor);
        }

        [Fact]
        public void PercentLabel_ShouldHaveCorrectProperties()
        {
            // Arrange
            var volumeComponent = new VolumeComponent();
            var frame = volumeComponent.CreateVolumeFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var label = (Label)flexLayout.Children[0];

            // Assert
            Assert.Equal("Hlasitost", label.Text);
            Assert.Equal(30, label.FontSize);
            Assert.Equal(LayoutOptions.Center, label.VerticalOptions);
            Assert.Equal(LayoutOptions.End, label.HorizontalOptions);
        }

        [Fact]
        public void Frame_ShouldHaveCorrectProperties()
        {
            // Arrange
            var volumeComponent = new VolumeComponent();
            var frame = volumeComponent.CreateVolumeFrame();

            // Assert
            Assert.Equal(20, frame.CornerRadius);
            Assert.Equal(Colors.DarkGray, frame.BackgroundColor);
        }

        [Fact]
        public async Task Slider_ValueChanged_ShouldSendDataToServer()
        {
            // Arrange
            var volumeComponent = new VolumeComponent();
            var frame = volumeComponent.CreateVolumeFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var slider = (Slider)flexLayout.Children[1];

            bool wasCalled = false;
            

            // Act
            slider.Value = 50;
            await Task.Delay(100); // Small delay to ensure async call

            // Assert
            Assert.True(wasCalled);
        }

        [Fact]
        public void UpdateProgress_ShouldUpdateSliderValue()
        {
            // Arrange
            var volumeComponent = new VolumeComponent();
            var frame = volumeComponent.CreateVolumeFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var slider = (Slider)flexLayout.Children[1];

            // Act
            volumeComponent.UpdateProgress(75);

            // Assert
            Assert.Equal(75, slider.Value);
        }

        [Fact]
        public async Task SendDataToServer_ShouldPostDataCorrectly()
        {
            // Arrange
            var volumeComponent = new VolumeComponent();
            var data = new { volume = 50 };
            var path = "http://example.com/api/volume";

            // Mocking HttpClient response
            var mockHttpClient = new Mock<HttpClient>();
            var mockResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };
            
            

            // Act
            await volumeComponent.SendDataToServer(data, path);

           
        }
    }
}
