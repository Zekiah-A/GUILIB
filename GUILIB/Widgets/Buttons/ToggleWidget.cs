using System;
using GUILIB.Core;
using GUILIB.Styles.Buttons;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets
{
    public class ToggleWidget : Widget
    {
        public event EventHandler OnButtonPressed;
        public bool isOn = true;
        
        private Color _currentBackgroundColour;

        private Color _currentOutlineColor;
        private Color _currentToggleColour;
        private Rectangle _toggle;
        private int _border;

        public ToggleWidget(Rectangle rectangle, Color background, bool state, int border)
        {
            widgetRectangle = rectangle;
            this.isOn = state;
            this._currentBackgroundColour = background;
            this._border = border;
        }

        public override void Update()
        {
            if (CheckCollisionRecs(widgetRectangle, Window.MouseRectangle))
            {
                if (IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    OnButtonPressed?.Invoke(this, EventArgs.Empty);
                    isOn = !isOn;
                }
            }
        }
        
        public override void Draw() //TODO: Add back buttonstyle. (toggle style)
        {
            DrawRectangleLinesEx(new Rectangle(widgetRectangle.x - _border / 2, widgetRectangle.y - _border / 2, widgetRectangle.width + _border, widgetRectangle.height+ _border),  /*buttonStyle.outlineThickness*/ 10, /*_currentOutlineColor*/ Color.GOLD);
            DrawRectangleRounded(widgetRectangle, /* buttonStyle.roundness*/ 0, 8,/* _currentBackgroundColour*/ new Color(185, 185, 185, 255));
            
            if(isOn)
            {
                DrawRectangleRounded(new Rectangle(widgetRectangle.x, widgetRectangle.y/*+_border/2*/, widgetRectangle.height, widgetRectangle.height/*-_border*/), 0, 8, new Color(200, 200, 200, 255));
            }else
            {
                DrawRectangleRounded(new Rectangle(widgetRectangle.x + widgetRectangle.width - widgetRectangle.height, widgetRectangle.y/*+_border/2*/, widgetRectangle.height, widgetRectangle.height/*-_border*/), 0, 8, new Color(200, 200, 200, 255));
            }
        }
    }
}