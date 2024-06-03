using Xunit;
using Microsoft.Maui.Controls;

namespace MauiApp1.Tests
{
    public class BasicComponenttest
    {
        [Fact]
        public void Label_ShouldHaveCorrectText()
        {
            // Arrange
            var label = new Label
            {
                Text = "Test Label"
            };

            // Assert
            Assert.Equal("Test Label", label.Text);
        }

        [Fact]
        public void Button_ShouldTriggerCommand()
        {
            // Arrange
            var wasClicked = false;
            var button = new Button
            {
                Command = new Command(() => wasClicked = true)
            };

            // Act
            button.Command.Execute(null);

            // Assert
            Assert.True(wasClicked);
        }
    }
}