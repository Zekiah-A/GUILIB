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

        public ToggleStyle _style;
        public bool isOn = true;

        public ToggleWidget(Rectangle rectangle, ToggleStyle style, bool state)
        {
            widgetRectangle = rectangle;
            this._style = style;
            this.isOn = state;
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
            DrawRectangleLinesEx(new Rectangle(widgetRectangle.x - _style.edgeBorder / 2, widgetRectangle.y - _style.edgeBorder / 2, widgetRectangle.width + _style.edgeBorder, widgetRectangle.height+ _style.edgeBorder), _style.edgeBorder, _style.borderColour);
            DrawRectangleRounded(widgetRectangle, _style.roundness, 8, _style.backgroundColour);
            
            if(isOn)
            {
                DrawRectangleRounded(new Rectangle(widgetRectangle.x, widgetRectangle.y, widgetRectangle.height, widgetRectangle.height), _style.roundness, 8, _style.switchColour);
            }else
            {
                DrawRectangleRounded(new Rectangle(widgetRectangle.x + widgetRectangle.width - widgetRectangle.height, widgetRectangle.y, widgetRectangle.height, widgetRectangle.height), _style.roundness, 8, _style.switchColour);
            }
        }
    }
}