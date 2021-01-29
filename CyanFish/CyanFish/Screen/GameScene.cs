using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    //*Add the Names of the Screens you would like to add here 
    public enum GameScreen { IntroScreen, PlayScreen, TutorialScreen, EndScreen}
    public class GameScene:DrawableGameComponent
    {
        protected SpriteBatch sb;
        protected Texture2D SceneTexture;
        public GameScreen State;
        public GameScene(Game game):base(game)
        {
           
        }
        public override void Initialize()
        {
            //Deactivates all screens on init
            this.Enabled = this.Visible = false;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (this.Visible == true)
            {
                sb.Begin();
                sb.Draw(this.SceneTexture, new Rectangle(this.Game.GraphicsDevice.Viewport.X, this.Game.GraphicsDevice.Viewport.Y, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height), Color.White);
                sb.End();
            }
            base.Draw(gameTime);
        }
    }
}
