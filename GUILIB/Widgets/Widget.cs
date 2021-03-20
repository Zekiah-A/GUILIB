using Raylib_cs;

namespace GUILIB.Widgets
{
    // To do: Add "size" and "position" variables that are accessible
    public abstract class Widget
    {
        protected Rectangle _widgetRectangle;
        protected Color _backgroundColor;
        protected Color _outlineColor;

        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
