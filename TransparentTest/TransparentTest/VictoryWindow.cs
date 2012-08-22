using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TransparentTest
{
    class VictoryWindow : Window
    {
        public string text;
        public SpriteFont font;

        public VictoryWindow(Vector2 pos, string text, SpriteFont font, IGUIManager manager)
            : base(pos, new Vector2(500, 300), 6, manager)
        {
            this.text = text;
            this.font = font;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            Vector2 sizeoftext = font.MeasureString(text);
            batch.Begin();
            batch.DrawString(font, text, new Vector2(position.X + ((size.X - sizeoftext.X) / 2), position.Y + 10), Color.Black);
            batch.End();
        }
    }
}
