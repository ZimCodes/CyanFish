using Microsoft.Xna.Framework;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Custom_Classes.Spawn
{
    public class TimedAreaSpawn:TimedSpawn
    {
        private Vector2 spawnArea;
        public TimedAreaSpawn(Game game):base(game)
        {

        }
        public override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// The area to spawn Game Component 
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public Vector2 AreaToSpawn(float minX, float maxX, float minY,float maxY)
        {
            spawnArea.X = (float)RandomManager.getRandom(minX,maxX);
            spawnArea.Y = (float)RandomManager.getRandom(minY, maxY);
            return spawnArea;
        }
    }
}
