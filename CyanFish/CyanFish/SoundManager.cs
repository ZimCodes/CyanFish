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
using Microsoft.Xna.Framework.Audio;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    public interface ISoundManager { }
    public class SoundManager:GameComponent,ISoundManager
    {
        private static SoundEffect BGMusic, Gulp, Chomp, SpawnCue;
        public SoundEffectInstance bgInstance, gulpInstance, chompInstance, spawncueInstance;
        public SoundManager(Game game) : base(game)
        {
            game.Services.AddService(typeof(ISoundManager), this);
        }
        public override void Initialize()
        {
            BGMusic = this.Game.Content.Load<SoundEffect>("Audio/BGSong");
            Gulp = this.Game.Content.Load<SoundEffect>("Audio/Gulp");
            Chomp = this.Game.Content.Load<SoundEffect>("Audio/Chomp");
            SpawnCue = this.Game.Content.Load<SoundEffect>("Audio/SoundCue");
            bgInstance = BGMusic.CreateInstance();
            gulpInstance = Gulp.CreateInstance();
            chompInstance = Chomp.CreateInstance();
            spawncueInstance = SpawnCue.CreateInstance();
            base.Initialize();
        }
    }
}
