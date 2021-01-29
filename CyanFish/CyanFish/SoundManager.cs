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
