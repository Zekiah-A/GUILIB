using System;
using GUILIB.Core;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Other
{
    public class BackgroundWidget : Widget
    {
        public Color backgroundColour;
        public float roundness;

        public BackgroundWidget(Rectangle rectangle, Color background, float roundness)
        {
            this.widgetRectangle = rectangle;
            this.backgroundColour = background;
            this.roundness = roundness;
        }

        public override void Draw()
        {
            DrawRectangleRounded(widgetRectangle, roundness, 8, backgroundColour);
        }
    }
}
