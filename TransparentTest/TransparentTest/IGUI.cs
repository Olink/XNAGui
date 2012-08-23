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
        bool Intersects(Vector2 p);
        void HandleInput(GameTime time);
        void Clicked(Vector2 p);
    }
}
