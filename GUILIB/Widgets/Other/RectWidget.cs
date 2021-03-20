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
        //private 
        private Color _backgroundColor;

        public RectWidget(Color background)
        {
            _backgroundColor = background;
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
            //DrawRectangle(_widgetRectangle);
            //DrawRectangle(int posX, int posY, int width, int height, Color color);
            DrawRectangle(10, 10, 10, 10, _backgroundColor);
        }
    }
}