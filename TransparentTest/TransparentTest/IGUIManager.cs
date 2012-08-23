using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TransparentTest
{
    interface IGUIManager
    {
        GraphicsDevice GetGraphics();
        void AddGui(IGUI g);
        SpriteFont GetFont(string p);
    }
}
