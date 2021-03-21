using GUILIB.Widgets;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GUILIB.Core
{
    public static class Window
    {
        public static string title;
        public static int width;
        public static int height;
        public static bool resizable;

        // To prevent System.StackOverflowException
        public static Rectangle mouseRectangle { private set; get; }

        /// <summary>
        ///     <para>Prepares all variables for Window class.</para>
        ///     Note: The minimum window size is going to be set according to the passed width and height. (Only if resizable is true).
        /// </summary>
        /// <param name="_title"> The window's title.</param>
        /// <param name="_width"> Sets the window's width.</param>
        /// <param name="_height"> Sets the window's height.</param>
        /// <param name="_resizable"> Enable or disable window resizing.</param>
        public static void Setup(string _title = "GUILIB", int _width = 1024, int _height = 576, bool _resizable = true)
        {
            title = _title;
            width = _width;
            height = _height;
            resizable = _resizable;
        }

        /// <summary>
        ///     <para>Initializes the window according to the given data.</para>
        ///     Note: Call this method BEFORE "Show()".
        /// </summary>
        public static void Run()
        {
            if (resizable)
            {
                SetConfigFlags(ConfigFlag.FLAG_WINDOW_RESIZABLE);
            }
            InitWindow(width, height, title);
            SetWindowMinSize(width, height);
            SetTargetFPS(60);
        }

        /// <summary>
        ///     Draws all widgets to the screen.
        /// </summary>
        /// <param name="widgets"> An array that contains all window's widgets.</param>
        public static void Draw(Widget[] widgets, Color backgroundColor)
        {

            while (!WindowShouldClose())
            {
                mouseRectangle = new Rectangle(GetMouseX(), GetMouseY(), 1, 1);

                foreach (Widget widget in widgets)
                {
                    widget.Update();
                }

                BeginDrawing();
                ClearBackground(backgroundColor);

                foreach (Widget widget in widgets)
                {
                    widget.Draw();
                }

                EndDrawing();
            }
            CloseWindow();
        }
    }
}
