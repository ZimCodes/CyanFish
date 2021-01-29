using Microsoft.Xna.Framework;
using MonoGameLibrary.Custom_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class PlayButton:Button
    {
        SwitchScreenManager switchScreen;
        public PlayButton(Game game):base(game)
        {
            switchScreen = (SwitchScreenManager)this.Game.Services.GetService(typeof(IScreenSwitch));
            if (switchScreen == null)
            {
                switchScreen = new SwitchScreenManager(this.Game);
                this.Game.Components.Add(switchScreen);
            }
        }
        protected override void LoadContent()
        {
            this.ButtonTexture = new MonoGameLibrary.Sprite.SpriteAnimation("Playbutton","playbutton",5,1,2);
            this.Location = new Vector2(this.Game.GraphicsDevice.Viewport.Width/2.5f,200);
            this.spriteAnimationAdapter.AddAnimation(ButtonTexture);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                HoverAnimation();
                GoToPlayScreen();
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
        private void HoverAnimation()
        {
            if (this.Hover())
            {
                spriteAnimationAdapter.GoToFrame(ButtonTexture, 0);
            }
            else
            {
                spriteAnimationAdapter.GoToFrame(ButtonTexture, 1);
            }
        }
        private void GoToPlayScreen()
        {
            if (this.ButtonClick(MonoGameLibrary.Util.MouseButtons.LeftButton))
            {
                switchScreen.NextScreen();
            }
        }
    }
}
