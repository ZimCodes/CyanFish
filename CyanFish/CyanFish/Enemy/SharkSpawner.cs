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
using MonoGameLibrary.Custom_Classes.Spawn;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class SharkSpawner:TimedAreaSpawn
    {
        SoundManager sm;
        public Shark shark;
        PlayScreen playscreen;
        Player fish;
        public SharkSpawner(Game game,PlayScreen screen,Player player):base(game)
        {
            shark = new Shark(this.Game,screen,player);
            SpawnEverySecond = (float)RandomManager.getRandom(6,20);
            playscreen = screen;
            fish = player;
            sm = (SoundManager)this.Game.Services.GetService(typeof(ISoundManager));
            if (sm == null)
            {
                sm = new SoundManager(this.Game);
                this.Game.Components.Add(sm);
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (playscreen.Enabled)
            {
                base.Update(gameTime);
            }
           
        }
        public override void Spawn()
        {
            if (playscreen.Enabled)
            {
                shark = new Shark(this.Game,playscreen,fish);
                shark.Initialize();
                shark.Location = this.AreaToSpawn(-(shark.width/1.1f), -(shark.width / 1.5f), 0, this.Game.GraphicsDevice.Viewport.Height);
                shark.Speed = (float)RandomManager.getRandom(70,150);
                this.Instance = shark;
                sm.spawncueInstance.Play();
                base.Spawn();
            }
            
        }
    }
}
