using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Other
{
    public class LabelWidget : Widget
    {
        public string text;
        public Color color;
        public bool wrapText;
        public int size;

        public LabelWidget(Rectangle rectangle, Color color, string text, bool wrapText, int size)
        {
            this.widgetRectangle = rectangle;
            this.color = color;
            this.text = text;
            this.wrapText = wrapText;
            this.size = size;
        }

        public override void Draw()
        {
            DrawTextRec(GetFontDefault(), text, widgetRectangle, size, size / 10, wrapText, color);
        }
    }
}
