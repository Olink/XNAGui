using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TransparentTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GUIManager guiManager;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        VictoryWindow vWindow;

        Texture2D tex2, tex3;

        SpriteFont font;

        ListBox box;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            guiManager = new GUIManager(GraphicsDevice);

            //window = new Window(new Vector2(10, 10), new Vector2(500, 300), 1, guiManager);
            
            Color[] data2 = new Color[1];
            data2[0] = Color.FromNonPremultiplied(255, 0, 0, 255);
            tex2 = new Texture2D(GraphicsDevice, 1, 1);
            tex2.SetData(data2);

            Color[] data3 = new Color[1];
            data3[0] = Color.FromNonPremultiplied(0, 0, 255, 255);
            tex3 = new Texture2D(GraphicsDevice, 1, 1);
            tex3.SetData(data3);

            font = Content.Load<SpriteFont>("Fonts/Default");

            guiManager.AddFont("default", font);
            //vWindow = new VictoryWindow(new Vector2(430, 10), "Victory!", font, guiManager);
            //box = new ListBox(400, 300, font, guiManager);
            //vWindow = new VictoryWindow(new Vector2(430, 10), "Victory!", font, guiManager);
            for (int i = 0; i < 100; i++)
            {
                //box.AddItem(i.ToString());
            }

            var field = new TextField(new Vector2(100, 400), new Vector2(400, 40), guiManager);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            guiManager.HandleInput(gameTime);
            guiManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            /*spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque);
            spriteBatch.Draw(tex2, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(800, 600), SpriteEffects.None, 1f);
            spriteBatch.Draw(tex3, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, new Vector2(400, 400), SpriteEffects.None, 1f);
            spriteBatch.End();*/

            guiManager.Draw(spriteBatch);

            //box.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
