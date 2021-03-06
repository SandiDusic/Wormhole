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

using Wormhole;

namespace TestingNamespace
{
    public class Testing : Microsoft.Xna.Framework.Game
    {
        //Basic game info:
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static GraphicsDevice Device;

        public Testing()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Device = graphics.GraphicsDevice;

            //Initialize game info:
            graphics.PreferredBackBufferWidth = 620;
            graphics.PreferredBackBufferHeight = 500;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Testing the Wormhole Wrapper";
            IsMouseVisible = true;

            //Initialize the static classes:
            ObjectHolder.Initialize();
            KeyboardManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Initialize the GameInfo:
            GameInfo.RefSpriteBatch = spriteBatch;
            GameInfo.RefDevice = Device;
            GameInfo.RefDeviceManager = graphics;
            GameInfo.RefContent = Content;

            //Initialize some more static classes:
            TextureHolder.Initialize();
            SoundHolder.Initialize();
            MouseManager.Initialize();

            //Initialize default sprites:
            TextureHolder.DefaultTextures[typeof(BlueObject)] = TextureHolder.AddTexture("BlueSquare");

            //Create the objects:
            ObjectHolder.Create(new BlueObject(new Vector2(0, 20)));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Events.RiseUpdate();
            Events.RiseUpdateEnded();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            spriteBatch.Begin();
            Events.RiseDraw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
