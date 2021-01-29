using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class TutorialScreen:GameScene
    {
        Texture2D tutTexture;
        InputHandler input;
        SwitchScreenManager switchScreen;
        public TutorialScreen(Game game):base(game)
        {
            State = GameScreen.TutorialScreen;
           input = (InputHandler)this.Game.Services.GetService(typeof(IInputHandler));
            if (input == null)
            {
                input = new InputHandler(this.Game);
                this.Game.Components.Add(input);
            }
            switchScreen = (SwitchScreenManager)this.Game.Services.GetService(typeof(IScreenSwitch));
            if (switchScreen == null)
            {
                switchScreen = new SwitchScreenManager(this.Game);
                this.Game.Components.Add(switchScreen);
            }
        }
        protected override void LoadContent()
        {
            this.SceneTexture = this.Game.Content.Load<Texture2D>("MenuBg");
            this.tutTexture = this.Game.Content.Load<Texture2D>("Instruction");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                GoBackToMenu();
                base.Update(gameTime);
            }
            
        }
        public override void Draw(GameTime gameTime)
        {
            if (this.Visible)
            {
                base.Draw(gameTime);
                sb.Begin();
                sb.Draw(this.tutTexture, new Rectangle(this.Game.GraphicsDevice.Viewport.X, this.Game.GraphicsDevice.Viewport.Y, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height), Color.White);
                sb.End();
            }
        }
        private void GoBackToMenu()
        {
            if(input.MouseState.WasMouseBtnPressed(MouseButtons.LeftButton)){
                switchScreen.ResetPosition();
            }
        }

    }
}
