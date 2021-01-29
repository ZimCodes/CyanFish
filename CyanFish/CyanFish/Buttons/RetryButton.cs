using Microsoft.Xna.Framework;
using MonoGameLibrary.Custom_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class RetryButton:Button
    {
        SwitchScreenManager switchScreen;
        SoundManager sm;
        public RetryButton(Game game):base(game)
        {
            switchScreen = (SwitchScreenManager)this.Game.Services.GetService(typeof(IScreenSwitch));
            if (switchScreen == null)
            {
                switchScreen = new SwitchScreenManager(this.Game);
                this.Game.Components.Add(switchScreen);
            }
            sm = (SoundManager)this.Game.Services.GetService(typeof(ISoundManager));
            if (sm == null)
            {
                sm = new SoundManager(this.Game);
                this.Game.Components.Add(sm);
            }
        }
        protected override void LoadContent()
        {
            this.ButtonTexture = new MonoGameLibrary.Sprite.SpriteAnimation("retrybutton","Retrybutton",5,1,2);
            this.spriteAnimationAdapter.AddAnimation(this.ButtonTexture);
            this.Location = new Vector2(this.Game.GraphicsDevice.Viewport.Width / 2.5f, 300);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                Animation();
                ClickButton();
                base.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            if (this.Visible)
            {
                base.Draw(gameTime);
            }
        }
        private void ClickButton()
        {
            if (this.ButtonClick(MonoGameLibrary.Util.MouseButtons.LeftButton))
            {
                ScoreManager.ResetGame();
                switchScreen.ScreenPlace(0,1);
            }
        }
        private void Animation()
        {
            if (this.Hover())
            {
                this.spriteAnimationAdapter.GoToFrame(this.ButtonTexture,0);
            }
            else
            {
                this.spriteAnimationAdapter.GoToFrame(this.ButtonTexture,1);
            }
        }
    }
}
