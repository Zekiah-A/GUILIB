using System;
using GUILIB.Styles.Buttons;
using GUILIB.Core;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Buttons
{
    public class ButtonWidget : Widget
    {
        public event EventHandler OnButtonPressed;
        public event EventHandler OnMouseExited;
        public event EventHandler OnMouseHover;

        public string text;
        public int textSize;
        public bool isToggled = false;
        public ButtonStyle buttonStyle;

        private Color _currentBackgroundColor;
        private Color _currentOutlineColor;
        private Color _currentTextColor;
        private Rectangle _textRectangle;

        public ButtonWidget(Rectangle rectangle, ButtonStyle buttonStyle, string text, int textSize)
        {
            _widgetRectangle = rectangle;
            this.buttonStyle = buttonStyle;
            this.text = text;
            this.textSize = textSize;
        }

        public override void Update()
        {
            if (CheckCollisionRecs(_widgetRectangle, Window.mouseRectangle))
            {
                if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    OnButtonPressed?.Invoke(this, EventArgs.Empty);
                    isToggled = !isToggled;
                    _currentBackgroundColor = buttonStyle.backgroundPressedColor;
                    _currentOutlineColor = buttonStyle.outlinePressedColor;
                    _currentTextColor = buttonStyle.outlinePressedColor;
                }
                else
                {
                    OnMouseHover?.Invoke(this, EventArgs.Empty);
                    _currentBackgroundColor = buttonStyle.backgroundHoverColor;
                    _currentOutlineColor = buttonStyle.outlineHoverColor;
                    _currentTextColor = buttonStyle.textHoverColor;
                }
            }
            else
            {
                OnMouseExited?.Invoke(this, EventArgs.Empty);
                _currentBackgroundColor = buttonStyle.backgroundIdleColor;
                _currentOutlineColor = buttonStyle.outlineIdleColor;
                _currentTextColor = buttonStyle.textIdleColor;
            }

            switch (buttonStyle.textMargin)
            {
                case "TopLeft":
                    _textRectangle = new Rectangle(_widgetRectangle.x + buttonStyle.outlineThickness, _widgetRectangle.y + buttonStyle.outlineThickness,
                                                   _widgetRectangle.width - buttonStyle.outlineThickness, _widgetRectangle.height - buttonStyle.outlineThickness);
                    break;
            }
        }

        public override void Draw()
        {
            DrawRectangleRounded(_widgetRectangle, buttonStyle.roundness, 8, _currentBackgroundColor);
            DrawRectangleLinesEx(_widgetRectangle, buttonStyle.outlineThickness, _currentOutlineColor);
            DrawTextRec(GetFontDefault(), text, _textRectangle, textSize, textSize / 10, true, _currentTextColor);
        }
    }
}
