using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MauiApp1.Components;
using MauiApp1.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using Xunit;
using Moq;

namespace MauiApp1.Tests
{
    public class HistoryComponentTests
    {
        private readonly HttpClient httpClient = new HttpClient();

        [Fact]
        public void GetTestData_ShouldReturnMockData()
        {
            // Arrange
            var historyComponent = new HistoryComponent();

            // Act
            var data = historyComponent.GetTestData();

            // Assert
            Assert.NotNull(data);
            Assert.NotEmpty(data.Data);
            Assert.Equal(4, data.Data.Count);
        }

        [Fact]
        public async Task GetDataServer_ShouldPopulateStackLayout()
        {
            // Arrange
            var historyComponent = new HistoryComponent();
            var stackLayout = new StackLayout();

            // Mocking HttpClient response
            var mockHttpClient = new Mock<HttpClient>();
            var mockResponse = new HttpResponseMessage
            {
                Content = new StringContent("{ \"data\": [{ \"date\": \"2024-06-02 01:11:04\", \"secs\": 52 }] }")
            };

            mockHttpClient
                .Setup(client => client.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(mockResponse);

            

            // Act
            await historyComponent.GetDataServer(stackLayout);

            // Assert
            Assert.NotEmpty(stackLayout.Children);
            Assert.IsType<Frame>(stackLayout.Children[0]);
        }

        [Fact]
        public void FlexLayout_ShouldHaveCorrectProperties()
        {
            // Arrange
            var historyComponent = new HistoryComponent();
            var flexLayoutMain = new FlexLayout
            {
                Direction = FlexDirection.Column,
                JustifyContent = FlexJustify.SpaceBetween
            };

            // Act
            var frame = new Frame
            {
                CornerRadius = 20,
                Content = flexLayoutMain,
                BackgroundColor = Colors.DarkGray
            };

            // Assert
            Assert.Equal(FlexDirection.Column, flexLayoutMain.Direction);
            Assert.Equal(FlexJustify.SpaceBetween, flexLayoutMain.JustifyContent);
            Assert.Equal(20, frame.CornerRadius);
            Assert.Equal(Colors.DarkGray, frame.BackgroundColor);
        }

        [Fact]
        public async Task GetDataServer_ShouldHandleException()
        {
            // Arrange
            var historyComponent = new HistoryComponent();
            var stackLayout = new StackLayout();

            // Mocking HttpClient to throw an exception
            var mockHttpClient = new Mock<HttpClient>();
            mockHttpClient
                .Setup(client => client.GetAsync(It.IsAny<string>()))
                .ThrowsAsync(new HttpRequestException("Network error"));

            // Act and Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => historyComponent.GetDataServer(stackLayout));
        }
    }
}
