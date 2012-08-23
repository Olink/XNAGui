using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TransparentTest
{
    public abstract class GUI : IGUI
    {
        protected Vector2 position;
        protected Vector2 size;

        public virtual Vector2 Position { get { return position; } set { position = value; } }
        public virtual Vector2 Size { get { return size; } set { size = value; } }

        public abstract void Draw(SpriteBatch batch);
        public abstract void Update(GameTime time);
        public abstract bool Intersects(Vector2 p);
        public abstract void HandleInput(GameTime time);
        public abstract void Clicked(Vector2 p);
    }
}
