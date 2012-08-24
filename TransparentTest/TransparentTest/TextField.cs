using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TransparentTest
{
    class TextField : Window
    {
        private string text;
        private IGUIManager guiManager;

        public TextField(Vector2 pos, Vector2 size, IGUIManager manager) : base(pos, size, 3, manager)
        {
            position = pos;
            this.size = size;
            guiManager = manager;
            manager.AddGui(this);
            text = string.Empty;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            StringBuilder builder = new StringBuilder();
            SpriteFont font = guiManager.GetFont("default");
            for (int i = text.Length - 1; i >= 0; i--)
            {
                builder.Append(text[i]);
                if(font.MeasureString(builder.ToString()).X > (size.X - 10))
                {
                    builder.Remove(builder.Length - 1, 1);
                    break;
                }
            }
            IEnumerable<char> rev = builder.ToString().Reverse<char>();
            string pri = string.Join("", rev);
            
            batch.Begin();
            batch.DrawString(font, pri, position + new Vector2(5,5), Color.Black);
            batch.End();
        }

        public override void Update(GameTime time)
        {
            //throw new NotImplementedException();
        }

        public override bool Intersects(Vector2 p)
        {
            return base.Intersects(p);
        }

        private KeyboardState oldState = Keyboard.GetState();
        private KeyboardState newState = Keyboard.GetState();

        public override void HandleInput(GameTime time)
        {
            //throw new NotImplementedException();
            newState = Keyboard.GetState();

            Keys[] newDown = newState.GetPressedKeys();
            Keys[] oldDown = oldState.GetPressedKeys();

            foreach(Keys k in oldDown)
            {
                if(!newDown.Contains(k))
                {
                    if(k == Keys.Back)
                    {
                        if (text.Length > 0) text = text.Substring(0, text.Length - 1);
                    }
                    else if(k == Keys.Space)
                    {
                        text += " ";
                    }
                    else
                    {
                        text += k.ToString();
                    }
                }
            }

            oldState = newState;
        }

        public override void Clicked(Vector2 p)
        {
            //throw new NotImplementedException();
        }
    }
}
