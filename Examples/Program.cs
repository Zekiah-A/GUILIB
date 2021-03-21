using System;
using GUILIB.Core;
using GUILIB.Widgets;
using GUILIB.Widgets.Buttons;
using GUILIB.Widgets.Other;
using GUILIB.Widgets.Text;
using GUILIB.Styles.Buttons;
using Raylib_cs;

namespace Examples
{
    class Program
    {
        static BackgroundWidget backgroundWidget = new BackgroundWidget(new Rectangle(32, 32, 128, 128), Color.GOLD, 0.25f);
        static ButtonWidget buttonWidget = new ButtonWidget(new Rectangle(64, 64, 64, 64), new ButtonStyle(), "Click me!", 15);

        //static string path = "cool.png";
        //static TextureBackgroundWidget textureBackgroundWidget = new TextureBackgroundWidget(path, 10, 20, Color.BLACK);

        static int clicksAmount;
        static LabelWidget labelWidget = new LabelWidget(new Rectangle(16, 16, 256, 32), Color.WHITE, $"Clicks: {clicksAmount}", true, 15);

        static ToggleWidget toggleWidget = new ToggleWidget(new Rectangle(64, 180, 64 ,20), Color.BLACK, true, 10);

        // Note: { backgroundWidget, buttonWidget } will look different than { buttonWidget, backgroundWidget}.
        //       Because it will draw the backgroundWidget THEN the buttonWidget. If you do the opposite you won't see the button.
        static Widget[] widgets = new Widget[] { backgroundWidget, buttonWidget, labelWidget, toggleWidget };

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

            clicksAmount++;
            labelWidget.text = $"Clicks: {clicksAmount}";
        }
    }
}
