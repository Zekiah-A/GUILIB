using System;
using GUILIB.Core;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace GUILIB.Widgets.Other
{
    public class TextureBackgroundWidget : Widget
    { 
        //Image image; 
        Texture2D texture ;
        public Color colour;
        public int posX;
        public int posY;

        public TextureBackgroundWidget(String path, int x, int y, Color background)
        {
            this.texture = LoadTexture(path); 
            this.posX = x;
            this.posY = y;
            this.colour = background; 
        }

        public override void Draw()
        {
            DrawTexture(texture, posX, posY, colour);
        }
    }
}