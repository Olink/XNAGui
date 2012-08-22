using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace TransparentTest
{
    class Line
    {
        private Vector2 position, length;
        private Texture2D texture;

        public Line(Texture2D tex, Vector2 position, Vector2 length)
        {
            texture = tex;
            this.position = position;
            this.length = length;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, length, SpriteEffects.None, 1f);
            batch.End();
        }
    }
}
