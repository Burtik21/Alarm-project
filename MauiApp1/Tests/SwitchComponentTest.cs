using System;
using System.Threading.Tasks;
using MauiApp1.Components;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using Xunit;
using Moq;

namespace MauiApp1.Tests
{
    public class SwitchComponentTest
    {
        [Fact]
        public void CreateSwitchFrame_ShouldCreateFrameWithComponents()
        {
            // Arrange
            var switchComponent = new SwitchComponent();

            // Act
            var frame = switchComponent.CreateSwitchFrame();

            // Assert
            Assert.NotNull(frame);
            Assert.NotNull(frame.Content);
            Assert.IsType<FlexLayout>(frame.Content);

            var flexLayout = (FlexLayout)frame.Content;
            Assert.Equal(2, flexLayout.Children.Count);
            Assert.IsType<Label>(flexLayout.Children[0]);
            Assert.IsType<Switch>(flexLayout.Children[1]);
        }

        [Fact]
        public async Task Switch_Toggled_ShouldSendDataToServer()
        {
            // Arrange
            var switchComponent = new SwitchComponent();
            var frame = switchComponent.CreateSwitchFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var toggleSwitch = (Switch)flexLayout.Children[1];

            bool wasCalled = false;
            // Replace SendDataToServer with a mock implementation for testing
            

            // Act
            toggleSwitch.IsToggled = true;
            await Task.Delay(100); // Small delay to ensure async call

            // Assert
            Assert.True(wasCalled);
        }

        [Fact]
        public void SwitchLabel_ShouldHaveCorrectProperties()
        {
            // Arrange
            var switchComponent = new SwitchComponent();
            var frame = switchComponent.CreateSwitchFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var switchLabel = (Label)flexLayout.Children[0];

            // Assert
            Assert.Equal("Zapnout:", switchLabel.Text);
            Assert.Equal(30, switchLabel.FontSize);
            Assert.Equal(10, switchLabel.Padding);
        }

        [Fact]
        public void ToggleSwitch_ShouldHaveCorrectProperties()
        {
            // Arrange
            var switchComponent = new SwitchComponent();
            var frame = switchComponent.CreateSwitchFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var toggleSwitch = (Switch)flexLayout.Children[1];

            // Assert
            Assert.Equal(60, toggleSwitch.WidthRequest);
            Assert.Equal(40, toggleSwitch.HeightRequest);
        }

        [Fact]
        public void Frame_ShouldHaveCorrectProperties()
        {
            // Arrange
            var switchComponent = new SwitchComponent();
            var frame = switchComponent.CreateSwitchFrame();

            // Assert
            Assert.Equal(20, frame.CornerRadius);
            Assert.IsType<FlexLayout>(frame.Content);
        }

        [Fact]
        public void FlexLayout_ShouldHaveCorrectProperties()
        {
            // Arrange
            var switchComponent = new SwitchComponent();
            var frame = switchComponent.CreateSwitchFrame();
            var flexLayout = (FlexLayout)frame.Content;

            // Assert
            Assert.Equal(FlexDirection.Row, flexLayout.Direction);
            Assert.Equal(FlexJustify.SpaceBetween, flexLayout.JustifyContent);
            Assert.Equal(FlexAlignItems.Center, flexLayout.AlignItems);
            Assert.Equal(new Thickness(0, 10, 0, 25), flexLayout.Margin);
        }
    }
}
