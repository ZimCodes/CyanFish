using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Custom_Classes;
using MonoGameLibrary.ScreenManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class IntroScreen:GameScene
    {
        SpriteFont sf;
        private ParallaxScrolling parallax;
        private Texture2D titleTexture;
        Button playButton,tutButton;
        SoundManager sm;
        public IntroScreen(Game game) : base(game)
        {
            State = GameScreen.IntroScreen;
            sm = (SoundManager)this.Game.Services.GetService(typeof(ISoundManager));
            if (sm == null)
            {
                sm = new SoundManager(this.Game);
                this.Game.Components.Add(sm);
            }
            
            parallax = new ParallaxScrolling(this.Game);
            this.Game.Components.Add(parallax);

            playButton = new PlayButton(this.Game);
            this.Game.Components.Add(playButton);

            tutButton = new TutorialButton(this.Game);
            this.Game.Components.Add(tutButton);

           
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
            this.titleTexture = this.Game.Content.Load<Texture2D>("Title");
            this.sf = this.Game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                this.playButton.Enabled = true;
                this.tutButton.Enabled = true;
                this.parallax.Update(gameTime);
            }
            else
            {
                playButton.Enabled = false;
                tutButton.Enabled = false;
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (this.Visible)
            {
                playButton.Visible = true;
                tutButton.Visible = true;
                this.parallax.Draw(gameTime);
                sb.Begin();
                sb.Draw(this.titleTexture, new Vector2(this.Game.GraphicsDevice.Viewport.Width / 3.5f, 50), Color.White);
                sb.DrawString(sf, ScoreManager.MuteMSG, new Vector2(0, this.Game.GraphicsDevice.Viewport.Height - 30), Color.DarkSlateGray);
                sb.End();
            }
            else
            {
                tutButton.Visible = false;
                playButton.Visible = false;
            }
        }
    }
}
