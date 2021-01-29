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
    class BombSpawner:TimedAreaSpawn
    {
        Bomb bomb;
        PlayScreen playScreen;
        Player fish;
        public BombSpawner(Game game,PlayScreen play,Player player):base(game)
        {
            this.SpawnEverySecond = (float)RandomManager.getRandom(3,12);
            bomb = new Bomb(game,play,player);
            playScreen = play;
            fish = player;
        }
        public override void Update(GameTime gameTime)
        {
            if (playScreen.Enabled)
            {
                base.Update(gameTime);
            }
        }
        public override void Spawn()
        {
            if (playScreen.Enabled)
            {
                bomb = new Bomb(this.Game,playScreen,fish);
                bomb.Initialize();
                bomb.Location = AreaToSpawn(0, this.Game.GraphicsDevice.Viewport.Width - bomb.width, -bomb.height, -10);
                this.Instance = bomb;
                base.Spawn();
            }
            
        }
    }
}
