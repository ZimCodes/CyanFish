using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.ScreenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class EndScreen:GameScene
    {
        SoundManager sm;
        private ParallaxScrolling parallax;
        RetryButton retrybtn;
        public EndScreen(Game game):base(game)
        {
            State = GameScreen.EndScreen;
            retrybtn = new RetryButton(game);
            this.Game.Components.Add(retrybtn);

             parallax = new ParallaxScrolling(game);
             this.Game.Components.Add(parallax);

            sm = (SoundManager)this.Game.Services.GetService(typeof(ISoundManager));
            if (sm == null)
            {
                sm = new SoundManager(this.Game);
                this.Game.Components.Add(sm);
            }
        }
        public override void Initialize()
        {
            parallax.Initialize();
            parallax.scrollSpeed = 0.5f;
            parallax.Direction = new Vector2(1,1);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            this.parallax.TextureName = "MenuBg";
            this.parallax.LoadContent();
            this.SceneTexture = this.Game.Content.Load<Texture2D>("MenuBg");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                
                ScreenText();
                retrybtn.Enabled = true;
                base.Update(gameTime);
                parallax.Update(gameTime); 
            }
            else
            {
                retrybtn.Enabled = false;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            if (this.Visible)
            {
                retrybtn.Visible = true;
                
                base.Draw(gameTime);
                parallax.Draw(gameTime);
            }
            else
            {
                retrybtn.Visible = false;
            }
            
        }
        private void ScreenText()
        {
            ScoreManager.HiScoreLoc = new Vector2(this.Game.GraphicsDevice.Viewport.Width / 2.5f, 100);
            ScoreManager.ScoreLoc = new Vector2(this.Game.GraphicsDevice.Viewport.Width / 2.2f, 200);
            ScoreManager.HiScoreSize = 2;
            ScoreManager.ScoreSize = 2;
        }
    }
}
