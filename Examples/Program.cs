using System;
using GUILIB.Core;
using GUILIB.Widgets;
using GUILIB.Widgets.Buttons;
using GUILIB.Styles.Buttons;
using Raylib_cs;

namespace Examples
{
    class Program
    {
        static ButtonWidget buttonWidget = new ButtonWidget(new Rectangle(64, 64, 64, 64), new ButtonStyle(), "Click me!", 15);
        static Widget[] widgets = new Widget[] { buttonWidget };

        static void Main()
        {
            buttonWidget.OnButtonPressed += ButtonWidget_OnButtonPressed;
            buttonWidget.OnMouseExited += ButtonWidget_OnMouseExited;
            buttonWidget.OnMouseHover += ButtonWidget_OnMouseHover;
            Window.Setup();
            Window.Run();
            Window.Draw(widgets, Color.GRAY);
        }

        private static void ButtonWidget_OnMouseHover(object sender, EventArgs eventArgs)
        {
            buttonWidget.textSize = 14;
            buttonWidget.text = "Hovering";
        }

        private static void ButtonWidget_OnMouseExited(object sender, EventArgs eventArgs)
        {
            buttonWidget.textSize = 14;
            buttonWidget.text = "Outside";
        }

        private static void ButtonWidget_OnButtonPressed(object sender, EventArgs eventArgs)
        {
            buttonWidget.textSize = 14;
            buttonWidget.text = "Pressed";
        }
    }
}
