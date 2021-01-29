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
