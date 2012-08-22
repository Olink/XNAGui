using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TransparentTest
{
    class ListBox : Window
    {
        int selected;
        int start;
        int max;
        List<String> items;
        int width, height;
        SpriteFont font;
        IGUIManager guiManager;

        public ListBox(int width, int height, SpriteFont font, IGUIManager manager) : base(new Vector2(0,0), new Vector2(width, height), 0, manager)
        {
            this.width = width;
            this.height = height;
            items = new List<String>();
            this.font = font;
            Vector2 size = font.MeasureString("test");

            max = (int)((height - 40) / size.Y);

            guiManager = manager;
            guiManager.AddGui(this);
        }

        public void AddItem(string s)
        {
            items.Add(s);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);

            batch.Begin();

            for (int i = 0; i < max; i++)
            {
                if ((start + i) >= items.Count)
                {
                    break;
                }

                int h = (int)font.MeasureString(items[start+i]).Y;
                Color chat = Color.Black;
                if ((start + i) == selected)
                {
                    chat = Color.Red;
                }

                batch.DrawString(font, items[start + i], new Vector2(0, 20 + i * h), chat);
            }
            batch.End();
        }

        public override void Update(GameTime time) { }

        private KeyboardState newState = Keyboard.GetState();
        private KeyboardState oldState = Keyboard.GetState();
        private DateTime LastKeyAccept = DateTime.Now;
        public override void HandleInput(GameTime time)
        {
            DateTime now = DateTime.Now;
            newState = Keyboard.GetState();
            //do stuff*********************************
            int elems = Math.Min(max, (items.Count - start));

            if (newState.IsKeyDown(Keys.Down) && (now - LastKeyAccept).Milliseconds > 50)
            {
                if (selected < items.Count - 1)
                {
                    selected++;
                }
                LastKeyAccept = now;
            }

            if (newState.IsKeyDown(Keys.Up) && (now - LastKeyAccept).Milliseconds > 50)
            {
                if (selected > 0)
                {
                    selected--;
                }
                LastKeyAccept = now;
            }

            if (selected >= start + elems)
            {
                start++;
            }
            else if (selected < start)
            {
                start--;
            }


            //*****************************************
            oldState = newState;
        }

        public override bool Intersects(Point p)
        {
            return ((p.X >= 0 && p.X <= width) && (p.Y >= 0 && p.Y <= height));
        }
    }
}
