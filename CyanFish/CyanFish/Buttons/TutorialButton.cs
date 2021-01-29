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
