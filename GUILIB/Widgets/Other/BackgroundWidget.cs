using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GUILIB.Widgets.Other
{
    public class BackgroundWidget : Widget
    {
        public float roundness;
        public int outlineThickness;

        public Color outlineColor = new Color(0, 0, 0, 255);

        public BackgroundWidget(Rectangle widgetRectangle, Color color, float roundness = 0.25f, int outlineThickness = 1) : base(widgetRectangle, color)
        {
            this.roundness = roundness;
            this.outlineThickness = outlineThickness;
        }

        public override void Draw()
        {
            DrawRectangleRoundedLines(widgetRectangle, roundness, 8, outlineThickness + 1, outlineColor);
            DrawRectangleRounded(widgetRectangle, roundness, 8, color);
        }
    }
}

