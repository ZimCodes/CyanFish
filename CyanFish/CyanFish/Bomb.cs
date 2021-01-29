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
using MonoGameLibrary.CollisionData;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class Bomb:DrawableAnimatableSprite
    {
        SpriteAnimation currentAnim, bombAlive;
        SwitchScreenManager switchScreen;
        SoundManager sm;
        PlayScreen playScreen;
        Player fish;
        public float width,height;
        private Rectangle rectCollision;
        public Bomb(Game game,PlayScreen play,Player player):base(game)
        {
            playScreen = play;
            fish = player;
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
            this.bombAlive = new SpriteAnimation("bombAlive","bombAlive",5,2,2);
            this.currentAnim = this.bombAlive;
            this.spriteAnimationAdapter.AddAnimation(this.currentAnim);
            this.Location = new Vector2(100,100);
            width = this.spriteAnimationAdapter.CurrentLocationRect.Width;
            height = this.spriteAnimationAdapter.CurrentLocationRect.Height;
            this.Speed = (float)RandomManager.getRandom(30, 160);
            this.Direction = Vector2.UnitY;
            rectCollision = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteAnimationAdapter.CurrentLocationRect.Width, this.spriteAnimationAdapter.CurrentLocationRect.Height);
            this.spriteAnimationAdapter.PauseAnimation(this.currentAnim);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (playScreen.Enabled)
            {
                this.Location = this.Location + this.Direction * this.Speed * (lastUpdateTime / 1000);
                rectCollision = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteAnimationAdapter.CurrentLocationRect.Width, this.spriteAnimationAdapter.CurrentLocationRect.Height);
                BombWithFish();
                Animation();
                Boundary();
                base.Update(gameTime);
            }
            else if(!playScreen.isPaused && !playScreen.Enabled)
            {
                for (int i = 0; i < this.Game.Components.Count; i++)
                {
                    if (this.ToString() == this.Game.Components[i].ToString())
                    {
                        this.Game.Components.Remove(this.Game.Components[i]);
                    }
                }
            }

        }
        public override void Draw(GameTime gameTime)
        {
            if (playScreen.Visible)
            {
                base.Draw(gameTime);
            }
        }
        private void Animation()
        {
            if (this.Location.Y < this.Game.GraphicsDevice.Viewport.Height/3)
            {
                this.spriteAnimationAdapter.GoToFrame(this.currentAnim,0);
            }
            else if (this.Location.Y >= this.Game.GraphicsDevice.Viewport.Height / 3 && this.Location.Y <= 2 * this.Game.GraphicsDevice.Viewport.Height / 3)
            {
                this.spriteAnimationAdapter.GoToFrame(this.currentAnim,1);
            }
            else if (this.Location.Y > 2 * this.Game.GraphicsDevice.Viewport.Height / 3 && this.Location.Y < this.Game.GraphicsDevice.Viewport.Height - this.spriteAnimationAdapter.CurrentLocationRect.Height)
            {
                this.spriteAnimationAdapter.GoToFrame(this.currentAnim,2);
            }
        }
        private void Boundary()
        {
            if (this.Location.Y > this.Game.GraphicsDevice.Viewport.Height - this.spriteAnimationAdapter.CurrentLocationRect.Height)
            {
                this.Location.Y = this.Game.GraphicsDevice.Viewport.Height - this.spriteAnimationAdapter.CurrentLocationRect.Height;
                if (switchScreen.Screens[2].State == GameScreen.EndScreen)
                {
                    switchScreen.ScreenPlace(0, 2);
                }
                else
                {
                    switchScreen.ScreenPlace(0, 1);
                }
            }
        }
        private void BombWithFish()
        {

            if (Collisions.RectangleRectangle(fish.rectCollision,this.rectCollision))
            {
                if (fish.PerPixelCollision(this))
                {
                    ScoreManager.Score++;
                    this.Enabled = this.Visible = false;
                    sm.chompInstance.Play();
                }
                
            }
        }
    }
}
