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
        SpriteFont font;
        IGUIManager guiManager;
        Vector2 fontSize;

        public ListBox(int width, int height, SpriteFont font, IGUIManager manager) : base(new Vector2(0,0), new Vector2(width, height), 0, manager)
        {
            size = new Vector2(width, height);
            items = new List<String>();
            this.font = font;
            fontSize = font.MeasureString("test");

            max = (int)((height - 40) / fontSize.Y);

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

            if (newState.IsKeyDown(Keys.Down) && (now - LastKeyAccept).Milliseconds > 50)
            {
                MoveDown();
                LastKeyAccept = now;
            }

            if (newState.IsKeyDown(Keys.Up) && (now - LastKeyAccept).Milliseconds > 50)
            {
                MoveUp();
                LastKeyAccept = now;
            }

            //*****************************************
            oldState = newState;
        }

        public override bool Intersects(Vector2 p)
        {
            return ((p.X >= 0 && p.X <= size.X) && (p.Y >= 0 && p.Y <= size.Y));
        }

        public override void Clicked(Vector2 p) 
        {
            Vector2 local = p - position;
            if ((int)local.Y < 20)
            {
                MoveUp();
            }
            else if ((int)local.Y > (position.Y + size.Y - 20))
            {
                MoveDown();
            }
            else
            {
                int index = (int)((local.Y - 20) / fontSize.Y);
                if (start + index < items.Count && index < max)
                {
                    selected = start + index;
                }
                
            }
        }

        private void MoveUp() 
        {
            if (selected > 0)
            {
                selected--;
            }

            if (selected < start)
            {
                start--;
            }
        }

        private void MoveDown()
        {
            int elems = Math.Min(max, (items.Count - start));
            if (selected < items.Count - 1)
            {
                selected++;
                if (selected >= start + elems)
                {
                    start++;
                }
            }
        }
    }
}
