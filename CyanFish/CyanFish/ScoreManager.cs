using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class ScoreManager:DrawableGameComponent
    {
        private SpriteBatch sb;
        private SpriteFont font,pausefont;
        public static int Score, HiScore;
        public static Vector2 ScoreLoc, HiScoreLoc;
        public static float ScoreSize, HiScoreSize;
        public static string PauseMSG,MuteMSG;
        public ScoreManager(Game game):base(game)
        {
            ResetGame();
            this.Enabled = this.Visible = false;
        }
        public static void ResetGame()
        {
            Score = 0;
            ScoreSize = HiScoreSize = 1;
            ScoreLoc = new Vector2(15,30);
            HiScoreLoc = new Vector2(15, 10);
            PauseMSG = "";
        }
        protected override void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            font = this.Game.Content.Load<SpriteFont>("font");
            pausefont = this.Game.Content.Load<SpriteFont>("pause");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (this.Enabled)
            {
                base.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            if (this.Visible)
            {
                sb.Begin();
                sb.DrawString(font, "Score: " + Score, ScoreLoc, Color.White, 0, new Vector2(0, 0), ScoreSize, SpriteEffects.None, 0);
                sb.DrawString(font, "Hi-Score: " + HiScore, HiScoreLoc, Color.White, 0, new Vector2(0, 0), HiScoreSize, SpriteEffects.None, 0);
                sb.DrawString(pausefont, PauseMSG, new Vector2(this.Game.GraphicsDevice.Viewport.Width/2.5f,this.Game.GraphicsDevice.Viewport.Height/2.5f), Color.WhiteSmoke, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                sb.End();
                base.Draw(gameTime);
            }
           
        }
    }
}
