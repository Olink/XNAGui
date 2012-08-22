using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TransparentTest
{
    class Window : IGUI
    {
        static Texture2D tex1;
        static Texture2D tex4;
        protected Vector2 position, size;
        int border;
        Line[] lines;
        IGUIManager guiManager;

        public Window(Vector2 pos, Vector2 size, int bor, IGUIManager manager)
        {
            position = pos;
            this.size = size;
            border = bor;
            guiManager = manager;

            Color[] data = new Color[1];
            Color[] data4 = new Color[1];
            data[0] = Color.FromNonPremultiplied(210, 210, 210, 220);
            tex1 = new Texture2D(guiManager.GetGraphics(), 1, 1);
            tex1.SetData(data);

            data4[0] = Color.FromNonPremultiplied(100, 100, 100, 255);
            tex4 = new Texture2D(guiManager.GetGraphics(), 1, 1);
            tex4.SetData(data4);

            lines = new Line[4];
            lines[0] = new Line(tex4, position - new Vector2(border, border), new Vector2(size.X + border * 2, border));
            lines[1] = new Line(tex4, position - new Vector2(border, border), new Vector2(border, size.Y + border * 2));
            lines[2] = new Line(tex4, new Vector2(position.X + size.X, position.Y - border), new Vector2(border, size.Y + border * 2));
            lines[3] = new Line(tex4, new Vector2(position.X - border, position.Y + size.Y), new Vector2(size.X + border, border));

            manager.AddGui(this);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            foreach (Line l in lines)
            {
                l.Draw(batch);
            }

            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            batch.Draw(tex1, position, null, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 1f);
            batch.End();
        }

        public virtual void Update(GameTime time) { }
        public virtual void HandleInput(GameTime time) { }

        public virtual bool Intersects(Point p)
        {
            return ((p.X >= position.X && p.X <= (position + size).X) && (p.Y >= position.Y && p.Y <= (position + size).Y));
        }
    }
}
