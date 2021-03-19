using Raylib_cs;

namespace GUILIB.Styles.ButtonWidget
{
    public class ButtonBaseStyle
    {
        public float buttonRoundness = 0.25f;

        public int textSize = 16;
        public int textOffset = 8;
        public string textMargin = "center";
        public Color textColor = new Color(64, 128, 64, 255);

        public Color idle = new Color(255, 255, 255, 255);
        public Color hover = new Color(255, 255, 255, 128);
        public Color pressed = new Color(200, 200, 200, 255);
    }
}
