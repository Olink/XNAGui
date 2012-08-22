using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TransparentTest
{
    interface IGUI
    {
        void Draw(SpriteBatch batch);
        void Update(GameTime time);
        bool Intersects(Point p);
        void HandleInput(GameTime time);
    }
}
