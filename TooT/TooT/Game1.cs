using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TooT
{
    public class TooTGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public TooTGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            OnCallback oncb = s => { Console.WriteLine("oncb: " + s); };
            OnCallback oncb1 = s => { Console.WriteLine("oncb1/2: " + s); };
            OnCallback oncb2 = oncb1;

            EventManager.Initialize();

            EventManager.Fire(Event.OnCallback, "no subscriptions");

            EventManager.Unsubscribe(Event.OnCallback, oncb);
            EventManager.Subscribe(Event.OnCallback, oncb);

            EventManager.Fire(Event.OnCallback, "1 subscription");

            EventManager.Subscribe(Event.OnCallback, oncb1);
            EventManager.Subscribe(Event.OnCallback, oncb2);

            EventManager.Fire(Event.OnCallback, "3 subscriptions");

            EventManager.Unsubscribe(Event.OnCallback, oncb1);

            EventManager.Fire(Event.OnCallback, "2 subscriptions");
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
