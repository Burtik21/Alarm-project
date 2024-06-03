using System.Net.Http.Json;
using Xunit;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using Moq;

namespace MauiApp1.Tests
{
    public class MainPageTests
    {
        [Fact]
        public void MainPage_ShouldCreateUIElements()
        {
            // Arrange
            var mainPage = new MainPage();

            // Act
            var content = mainPage.Content;

            // Assert
            Assert.NotNull(content);
            Assert.IsType<StackLayout>(content);

            var stackLayout = (StackLayout)content;
            Assert.Equal(3, stackLayout.Children.Count);
        }

        [Fact]
        public async Task MainPage_ShouldSendDataToServer()
        {
            // Arrange
            var mainPage = new MainPage();
            var toggleSwitch = new Switch();

            // Mocking HttpClient response
            var mockHttpClient = new Mock<HttpClient>();
            var mockResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };

            
        }
    }
}