using System;
using Raylib_cs;
using static Raylib_cs.Raylib;
using GUILIB.Core;

namespace GUILIB.Widgets
{
    public abstract class Widget
    {
        public event EventHandler OnMouseHover;
        public event EventHandler OnMouseExited;

        /// <summary>
        ///     Use to change the widget's position and size.
        /// </summary>
        public Rectangle widgetRectangle;
        
        protected Color _backgroundColor;
        protected Color _outlineColor;

        public virtual void Update()
        {
            if (CheckCollisionRecs(widgetRectangle, Window.mouseRectangle))
            {
                OnMouseHover?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                OnMouseExited?.Invoke(this, EventArgs.Empty);
            }
        }

        public virtual void Draw()
        {
            DrawRectangleRec(widgetRectangle, _backgroundColor);
        }
    }
}
