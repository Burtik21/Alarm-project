using System;
using System.Threading.Tasks;
using MauiApp1.Components;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using Xunit;
using Moq;

namespace MauiApp1.Tests
{
    public class TimePickerComponentTest
    {
        [Fact]
        public void CreateTimePickerFrame_ShouldCreateFrameWithComponents()
        {
            // Arrange
            var timePickerComponent = new TimePickerComponent();

            // Act
            var frame = timePickerComponent.CreateTimePickerFrame();

            // Assert
            Assert.NotNull(frame);
            Assert.NotNull(frame.Content);
            Assert.IsType<FlexLayout>(frame.Content);

            var flexLayout = (FlexLayout)frame.Content;
            Assert.Equal(2, flexLayout.Children.Count);
            Assert.IsType<Label>(flexLayout.Children[0]);
            Assert.IsType<TimePicker>(flexLayout.Children[1]);
        }

        [Fact]
        public void TimePicker_ShouldHaveCorrectProperties()
        {
            // Arrange
            var timePickerComponent = new TimePickerComponent();
            var frame = timePickerComponent.CreateTimePickerFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var timePicker = (TimePicker)flexLayout.Children[1];

            // Assert
            Assert.Equal("HH:mm", timePicker.Format);
            Assert.Equal(20, timePicker.FontSize);
        }

        [Fact]
        public void TimePickerLabel_ShouldHaveCorrectProperties()
        {
            // Arrange
            var timePickerComponent = new TimePickerComponent();
            var frame = timePickerComponent.CreateTimePickerFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var timePickerLabel = (Label)flexLayout.Children[0];

            // Assert
            Assert.Equal("Čas:", timePickerLabel.Text);
            Assert.Equal(30, timePickerLabel.FontSize);
            Assert.Equal(10, timePickerLabel.Padding);
        }

        [Fact]
        public void Frame_ShouldHaveCorrectProperties()
        {
            // Arrange
            var timePickerComponent = new TimePickerComponent();
            var frame = timePickerComponent.CreateTimePickerFrame();

            // Assert
            Assert.Equal(20, frame.CornerRadius);
            Assert.IsType<FlexLayout>(frame.Content);
        }

        [Fact]
        public void FlexLayout_ShouldHaveCorrectProperties()
        {
            // Arrange
            var timePickerComponent = new TimePickerComponent();
            var frame = timePickerComponent.CreateTimePickerFrame();
            var flexLayout = (FlexLayout)frame.Content;

            // Assert
            Assert.Equal(FlexDirection.Row, flexLayout.Direction);
            Assert.Equal(FlexJustify.SpaceBetween, flexLayout.JustifyContent);
            Assert.Equal(FlexAlignItems.Center, flexLayout.AlignItems);
            Assert.Equal(new Thickness(0, 10, 0, 25), flexLayout.Margin);
        }

        [Fact]
        public async Task TimePicker_ValueChanged_ShouldTriggerEvent()
        {
            // Arrange
            var timePickerComponent = new TimePickerComponent();
            var frame = timePickerComponent.CreateTimePickerFrame();
            var flexLayout = (FlexLayout)frame.Content;
            var timePicker = (TimePicker)flexLayout.Children[1];

            bool eventTriggered = false;
            

            // Act
            timePicker.Time = new TimeSpan(14, 30, 0);
            await Task.Delay(100); // Small delay to ensure async call

            // Assert
            Assert.True(eventTriggered);
        }
    }
}
