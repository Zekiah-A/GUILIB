using System.Numerics;
using System;
using GUILIB.Widgets;
using GUILIB.Styles.ButtonWidget;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GUILIB.Widgets
{
    public class ButtonWidget
    {
        public event EventHandler onButtonToggle;
        public event EventHandler onMouseEnter;
        public event EventHandler onMouseExit;

        public Vector2 position;
        public Vector2 size;
        public ButtonBaseStyle buttonStyle;
        public string text;
        public string tooltipText;
        public bool toggled = false;

        private Rectangle _buttonRectangle;
        private Color _currentColor;

        public ButtonWidget(Vector2 position, Vector2 size, ButtonBaseStyle buttonStyle, string text)
        {
            this.position = position;
            this.size = size;
            this.buttonStyle = buttonStyle;
            this.text = text;

            this._buttonRectangle = new Rectangle(this.position.X, this.position.Y,
                                                  this.size.X, this.size.Y);
        }

        public void Update()
        {
            Rectangle mouseRectangle = new Rectangle(GetMouseX(), GetMouseY(), 1, 1);
            if (CheckCollisionRecs(_buttonRectangle, mouseRectangle))
            {
                if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    toggled = !toggled;
                    onButtonToggle?.Invoke(this, EventArgs.Empty);
                    _currentColor = buttonStyle.pressed;
                }
                else
                {
                    onMouseEnter?.Invoke(this, EventArgs.Empty);
                    _currentColor = buttonStyle.hover;

                }
            }
            else
            {
                onMouseExit?.Invoke(this, EventArgs.Empty);
                _currentColor = buttonStyle.idle;
            }
        }

        public void Show()
        {
            Vector2 textPosition = position;
            
            Update();
            DrawRectangleRounded(_buttonRectangle, buttonStyle.buttonRoundness, 8, _currentColor);
            DrawText(text, (int)textPosition.X, (int)textPosition.Y, buttonStyle.textSize, buttonStyle.textColor);
        }
    }
}
