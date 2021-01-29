/*  CyanFish is an open-source 2D 'collect them all' game created in using MonoGame.
      Copyright (C) 2018  ZimCodes

      This program is free software: you can redistribute it and/or modify
      it under the terms of the GNU General Public License as published by
      the Free Software Foundation, either version 3 of the License, or
      (at your option) any later version.

      This program is distributed in the hope that it will be useful,
      but WITHOUT ANY WARRANTY; without even the implied warranty of
      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      GNU General Public License for more details.*/
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
