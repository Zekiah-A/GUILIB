using Raylib_cs;

namespace GUILIB.Styles.Buttons
{
    public class ButtonStyle
    {
        #region Colours
        public Color backgroundIdleColor = new Color(200, 200, 200, 255);
        public Color backgroundHoverColor = new Color(230, 230, 230, 255);
        public Color backgroundPressedColor = new Color(100, 100, 100, 255);

        public Color outlineIdleColor = new Color(185, 185, 185, 255);
        public Color outlineHoverColor = new Color(200, 200, 200, 255);
        public Color outlinePressedColor = new Color(85, 85, 85, 255);

        public Color textIdleColor = new Color(235, 235, 235, 255);
        public Color textHoverColor = new Color(255, 255, 255, 255);
        public Color textPressedColor = new Color(150, 150, 150, 255);
        #endregion

        public float roundness = 0.25f;
        public int outlineThickness = 3;
        public string textMargin = "TopLeft";
    }
}
