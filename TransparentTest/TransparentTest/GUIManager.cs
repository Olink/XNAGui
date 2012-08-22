using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TransparentTest
{
    class GUIManager : IGUIManager
    {
        private GraphicsDevice graphics;
        private List<IGUI> elements;

        public GUIManager(GraphicsDevice graphics)
        {
            this.graphics = graphics;
            elements = new List<IGUI>();
        }

        public void AddGui(IGUI gui)
        {
            elements.Add(gui);
        }

        public GraphicsDevice GetGraphics()
        {
            return graphics;
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (IGUI gui in elements)
            {
                gui.Draw(batch);
            }
        }

        public void Update(GameTime time)
        {
            foreach (IGUI gui in elements)
            {
                gui.Update(time);
            }
        }

        private MouseState newState = Mouse.GetState();
        private MouseState oldState = Mouse.GetState();
        private int selected = 0;
        public void HandleInput(GameTime time)
        {
            int temp = -1;
            newState = Mouse.GetState();
            if (newState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
            {
                for(int i = 0; i < elements.Count; i++)
                {
                    IGUI gui = elements[i];
                    if (gui.Intersects(new Point(oldState.X, oldState.Y)))
                    {
                        temp = i;
                        break;
                    }
                }
            }

            if (temp != -1)
            {
                selected = temp;
            }

            elements[selected].HandleInput(time);

            oldState = newState;
        }
    }
}
