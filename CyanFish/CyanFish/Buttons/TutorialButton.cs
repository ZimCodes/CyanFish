using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Custom_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class TutorialButton:Button
    {
        
        SwitchScreenManager switchScreen;
        public TutorialButton(Game game):base(game)
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
            this.ButtonTexture = new MonoGameLibrary.Sprite.SpriteAnimation("TutButton","Creditbutton",5,1,2);
            this.spriteAnimationAdapter.AddAnimation(ButtonTexture);
            this.Location = new Vector2(this.Game.GraphicsDevice.Viewport.Width / 2.5f, 275);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                HoverAnimation();
                OnClickAction();
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
                this.spriteAnimationAdapter.GoToFrame(this.ButtonTexture, 0);
            }
            else
            {
                this.spriteAnimationAdapter.GoToFrame(this.ButtonTexture, 1);
            }
        }
        private void OnClickAction()
        {
            if (this.ButtonClick(MonoGameLibrary.Util.MouseButtons.LeftButton))
            {
              switchScreen.ScreenPlace(0, 2);
            }
        }
    }
}
