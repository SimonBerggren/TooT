using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TooT.Core.ParticleSystem;

namespace TooT
{
    internal class TooTGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        internal const int Width = 1280;
        internal const int Height = 720;

        internal TooTGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            Content.RootDirectory = "Content";

            EventManager.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentManager.LoadContent(Content);
            SceneManager.Initialize();
            SceneManager.AddScene(new MainMenuScene());
        }

        protected override void Update(GameTime gameTime)
        {
            ParticleEngine.Instance.Update(gameTime);
            InputManager.Update();
            if (/*InputManager.IsKeyPressed(Keys.Escape) ||*/ !SceneManager.Update(gameTime))
                Exit();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            SceneManager.Draw(spriteBatch);
            ParticleEngine.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
