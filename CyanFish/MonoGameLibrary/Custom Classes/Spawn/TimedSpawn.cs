using Microsoft.Xna.Framework;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Custom_Classes.Spawn
{
    public class TimedSpawn:Spawner
    {
        private Timer timer;
        protected float SpawnEverySecond = 3;
        public TimedSpawn(Game game):base(game)
        {
            timer = new Timer(this.Game);
        }
        public override void Update(GameTime gameTime)
        {
            SpawnTimer(gameTime);
            base.Update(gameTime);
        }
        public virtual void SpawnTimer(GameTime gameTime)
        {
            timer.PlayTimerContinuous(SpawnEverySecond, gameTime);
            if (timer.IsTimeUp)
            {
                this.Spawn();
            }
        }
    }
}
