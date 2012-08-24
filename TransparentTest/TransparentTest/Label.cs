using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TransparentTest
{
    enum Justification
    {
        LEFT,
        CENTER,
        RIGHT,
    }

    class Label : Window
    {
        IGUIManager guiManager;
        string text;
        Justification just;

        public Label(Vector2 pos, Vector2 size, String text, Justification just, IGUIManager manager) : base(pos, size, 1, manager)
        {
            position = pos;
            this.size = size;
            this.text = text;
            guiManager = manager;
            this.just = just;
            manager.AddGui(this);
        }

        public override void Draw(SpriteBatch batch)
        {
            SpriteFont font = guiManager.GetFont("default");
            base.Draw(batch);
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            batch.DrawString(font, text, CalcPosition(font), Color.Black);
            batch.End();
        }

        public override void Update(GameTime time) { }
        public override void HandleInput(GameTime time) { }

        public override bool Intersects(Vector2 p)
        {
            return ((p.X >= position.X && p.X <= (position + size).X) && (p.Y >= position.Y && p.Y <= (position + size).Y));
        }

        public override void Clicked(Vector2 p) { }

        private Vector2 CalcPosition(SpriteFont font)
        {
            if (just == Justification.CENTER)
            {
                Vector2 w = font.MeasureString(text);
                return new Vector2(position.X + ((size - w).X / 2), position.Y);
            }

            if (just == Justification.RIGHT)
            {
                Vector2 w = font.MeasureString(text);
                return new Vector2(position.X + size.X - w.X, position.Y);
            }

            return position;
        }
    }
}
