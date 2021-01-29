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
