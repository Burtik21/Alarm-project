using Xunit;
using MauiApp1.Components;
using Microsoft.Maui.Controls;

namespace MauiApp1.Tests
{
    public class ComponentBehaviorTest
    {
        [Fact]
        public void ToggleSwitch_ShouldInvokeToggledEvent()
        {
            // Arrange
            var switchComponent = new SwitchComponent();
            var frame = switchComponent.CreateSwitchFrame();
            var toggleSwitch = switchComponent.ToggleSwitch;
            bool wasToggled = false;
            
            toggleSwitch.Toggled += (sender, e) => { wasToggled = true; };

            // Act
            toggleSwitch.IsToggled = !toggleSwitch.IsToggled;

            // Assert
            Assert.True(wasToggled);
        }

        [Fact]
        public void TimePicker_ShouldInvokeTimeChangedEvent()
        {
            // Arrange
            var timePickerComponent = new TimePickerComponent();
            var frame = timePickerComponent.CreateTimePickerFrame();
            var timePicker = timePickerComponent.TimePicker;
            bool wasChanged = false;
            
            timePicker.PropertyChanged += (sender, e) => 
            { 
                if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
                {
                    wasChanged = true;
                }
            };

            // Act
            timePicker.Time = new TimeSpan(14, 30, 0);

            // Assert
            Assert.True(wasChanged);
        }
    }
}