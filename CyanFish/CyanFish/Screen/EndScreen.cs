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
