using System;
using GUILIB.Core;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets
{
    public class ToggleButtonWidget : Widget
    {
        /// <summary>
        ///     Invoked when the toggle button is pressed.
        /// </summary>
        public event EventHandler OnButtonToggled;

        public float roundness;
        public float buttonRoundness;
        public int outlineThickness;
        public int outlineButtonThickness;
        public bool isToggled = false;

        public Color buttonColor = new Color(0, 0, 0, 255);
        public Color outlineColor = new Color(0, 0, 0, 255);
        public Color outlineButtonColor = new Color(0, 0, 0, 255);
        public Rectangle buttonRectangle;

        public ToggleButtonWidget(Rectangle widgetRectangle, Color color, bool scales, float roundness = 0.25f, int outlineThickness = 1) : base(widgetRectangle, color, scales)
        {
            this.roundness = roundness;
            this.buttonRoundness = roundness;
            this.outlineThickness = outlineThickness;
            this.outlineButtonThickness = outlineThickness;
            this.buttonRectangle = new Rectangle(widgetRectangle.x, widgetRectangle.y,
                                                 widgetRectangle.width / 3, widgetRectangle.height);
        }

        public override void Update()
        {
            if (CheckCollisionRecs(buttonRectangle, Window.MouseRectangle))
            {
                if (IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    OnButtonToggled?.Invoke(this, EventArgs.Empty);
                    if (isToggled)
                    {
                        if(scales)
                        {
                            float scaledWidth =  widgetRectangle.width / 3 / 100 * GetScreenWidth();
                            buttonRectangle = new Rectangle(widgetRectangle.x, widgetRectangle.y,
                                                            scaledWidth, (widgetRectangle.height / 100) * GetScreenHeight());
                        }
                        else
                        {
                            buttonRectangle = new Rectangle(widgetRectangle.x, widgetRectangle.y,
                                                            widgetRectangle.width / 3, widgetRectangle.height);
                        }
                    }
                    else
                    {
                        if(scales)
                        {
                            float scaledWidth =  widgetRectangle.width / 3 / 100 * GetScreenWidth();
                            buttonRectangle = new Rectangle(widgetRectangle.x + scaledWidth - buttonRectangle.width, widgetRectangle.y,
                                                            scaledWidth, (widgetRectangle.height / 100) * GetScreenHeight());
                        }
                        else
                        {
                            buttonRectangle = new Rectangle(widgetRectangle.x + widgetRectangle.width - buttonRectangle.width, widgetRectangle.y,
                                                            widgetRectangle.width / 3, widgetRectangle.height);
                        }
                    }
                    isToggled = !isToggled;
                }
            }
        }

        public override void Draw()
        { //widgetRectangle.x, widgetRectangle.y, (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()
            if(scales)
            {
                DrawRectangleRoundedLines(new Rectangle(widgetRectangle.x, widgetRectangle.y, (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()), roundness, 8, outlineThickness + 1, outlineColor);
                DrawRectangleRounded(new Rectangle(widgetRectangle.x, widgetRectangle.y, (widgetRectangle.width / 100) * GetScreenWidth(), (widgetRectangle.height / 100) * GetScreenHeight()), roundness, 8, color);

                DrawRectangleRoundedLines(buttonRectangle, buttonRoundness, 8, outlineButtonThickness + 1, outlineButtonColor);
                DrawRectangleRounded(buttonRectangle, buttonRoundness, 8, buttonColor);
            }else
            {
                DrawRectangleRoundedLines(widgetRectangle, roundness, 8, outlineThickness + 1, outlineColor);
                DrawRectangleRounded(widgetRectangle, roundness, 8, color);
            
                DrawRectangleRoundedLines(buttonRectangle, buttonRoundness, 8, outlineButtonThickness + 1, outlineButtonColor);
                DrawRectangleRounded(buttonRectangle, buttonRoundness, 8, buttonColor);
            }
        }
    }
}