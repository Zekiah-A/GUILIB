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
        
    private int _posX; private int _posY;
    private int _width; private int _height;
        private Color _backgroundColor;

        public RectWidget(int Xposition, int Yposition, int horizontal, int vertical, Color background)
        {
            _posX = Xposition;
            _posY = Yposition;
            _width = horizontal;
            _height = vertical;
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
            DrawRectangle(_posX, _posY, _width, _height, _backgroundColor);
        }
    }
}
