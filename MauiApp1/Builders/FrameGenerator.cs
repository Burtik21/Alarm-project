using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace MauiApp1.Builders;

public class FrameGenerator
{
    public Frame CreateFrame(View label, View control)
    {
        var flexLayout = new FlexLayout
        {
            Direction = FlexDirection.Row,
            JustifyContent = FlexJustify.SpaceBetween
        };

        flexLayout.Children.Add(label);
        flexLayout.Children.Add(control);

        var frame = new Frame
        {
            CornerRadius = 20,
            Content = flexLayout
        };

        return frame;
    }
}