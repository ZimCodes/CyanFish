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
    class Shark:DrawableAnimatableSprite
    {
        SoundManager sm;
        SwitchScreenManager switchScreen;
        SpriteAnimation currentAnim, Moving, Eating;
        PlayScreen PlayScreen;
        public float width;
        public Rectangle rectCollision;
        Player player;
        public Shark(Game game,PlayScreen play,Player fish):base(game)
        {
            PlayScreen = play;
            player = fish;
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
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            this.Moving = new SpriteAnimation("Moving","SharkMoving",5,2,2);
            this.Eating = new SpriteAnimation("Eating","EatingShark",5,2,1);
            this.currentAnim = this.Moving;
            this.spriteAnimationAdapter.AddAnimation(this.currentAnim);
            this.Direction = Vector2.UnitX;
            this.Speed = 100;
            width = this.spriteAnimationAdapter.CurrentLocationRect.Width;
           
            base.LoadContent();
            rectCollision = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteAnimationAdapter.CurrentLocationRect.Width, this.spriteAnimationAdapter.CurrentLocationRect.Height);
        }
        public override void Update(GameTime gameTime)
        {
            if (PlayScreen.Enabled)
            {
                rectCollision = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteAnimationAdapter.CurrentLocationRect.Width, this.spriteAnimationAdapter.CurrentLocationRect.Height);
                this.Location = this.Location + this.Direction * ((lastUpdateTime / 1000) * this.Speed);
                DisableShark();
                SharkWithFish();
                base.Update(gameTime);
                
            }
            else if(!PlayScreen.isPaused && !PlayScreen.Enabled)
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
            if (PlayScreen.Visible)
            {
                base.Draw(gameTime);
            }
            
        }
        private void SharkWithFish()
        {
            if (Collisions.RectangleRectangle(this.rectCollision, player.rectCollision))
            {
                if (player.PerPixelCollision(this))
                {
                    sm.gulpInstance.Play();
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
        }
        private void DisableShark()
        {
            if (this.Location.X < -spriteAnimationAdapter.CurrentLocationRect.Width || this.Location.X > this.Game.GraphicsDevice.Viewport.Width + this.spriteAnimationAdapter.CurrentLocationRect.Width)
            {
                this.Enabled = this.Visible = false;
            }
            if (this.Location.Y < -spriteAnimationAdapter.CurrentLocationRect.Height || this.Location.Y > this.Game.GraphicsDevice.Viewport.Height + this.spriteAnimationAdapter.CurrentLocationRect.Height)
            {
                this.Enabled = this.Visible = false;
            }
        }
    }
}
