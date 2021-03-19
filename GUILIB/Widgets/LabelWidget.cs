using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GUILIB.Widgets
{
    public class LabelWidget
    {
        public Vector2 position;
        public Color color;
        public int fontSize;
        public string text;

        public LabelWidget(Vector2 position, Color color, int fontSize, string text)
        {
            this.position = position;
            this.color = color;
            this.fontSize = fontSize;
            this.text = text;
        }

        public void Show()
        {
            DrawText(text, (int)position.X, (int)position.Y, fontSize, color);
        }
    }
}
