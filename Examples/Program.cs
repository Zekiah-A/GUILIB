using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Examples
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #region WindowsInit
            SetConfigFlags(ConfigFlag.FLAG_WINDOW_RESIZABLE);
            InitWindow(1024, 576, "GUILIB Examples");
            SetWindowMinSize(1024, 576);
            SetTargetFPS(60);
            #endregion

            while (!WindowShouldClose())
            {
                BeginDrawing();
                ClearBackground(new Color(245, 245, 245, 255));
                EndDrawing();
            }
            CloseWindow();
        }

    }
}
