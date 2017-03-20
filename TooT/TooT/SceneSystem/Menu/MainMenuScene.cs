using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TooT.SceneSystem;

namespace TooT
{
    class MainMenuScene : MenuScene
    {
        internal MainMenuScene() : base()
        {
            EntryDesc menuDesc = new EntryDesc(ContentManager.Font, new Vector2(SceneManager.Width / 2, SceneManager.Height), new Vector2(SceneManager.Width / 2, SceneManager.Height / 2));
            menuDesc.Color = Color.Coral;
            menuDesc.SelectedColor = Color.LightBlue;

            Set_Desc(menuDesc);
            AddEntry("Start", Start);
            AddEntry("Level Editor", Edit);
            AddEntry("Exit", Close);
        }

        internal override bool HandleTransition(GameTime _GT)
        {
            return base.HandleTransition(_GT);
        }

        internal override void Update(GameTime _GT)
        {
            base.Update(_GT);
        }

        internal override void Draw(SpriteBatch _SB)
        {
            base.Draw(_SB);
        }

        private void Start()
        {
            SceneManager.AddScene(new GameScene());
        }

        private void Edit()
        {
        }
    }
}