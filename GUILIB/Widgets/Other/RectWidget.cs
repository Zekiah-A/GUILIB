using System;
using GUILIB.Core;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Other
{
    public class RectWidget : Widget
    {
        public event EventHandler OnMouseHover;   
        public event EventHandler OnMouseExited;
        
        private Rectangle _rec;
        private Color _backgroundColour;

        public RectWidget(Rectangle rectangle, Color background)
        {
            _rec = rectangle;
            _backgroundColour = background;
        }

        public override void Update()
        {
            if (CheckCollisionRecs(_widgetRectangle, Window.mouseRectangle))
            {
                OnMouseHover?.Invoke(this, EventArgs.Empty);
            } 
            else
            {
                OnMouseExited?.Invoke(this, EventArgs.Empty);
            }
        }
        public override void Draw()
        {
            DrawRectangleRec(_rec, _backgroundColour); 
        }
    }
}
