using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.ScreenManagement
{
    public interface IParallaxScrolling { }
    public class ParallaxScrolling:GameComponent, IParallaxScrolling
    {
        public Vector2 Direction;
        public string TextureName;
        private Texture2D currentBG;
        public float scrollSpeed;
        private Vector2 currentOffset;
        private Rectangle currentRect, nextRect, prevRect;
        private Rectangle prevTopRect, nextTopRect, currentTopRect;
        private Rectangle prevBottomRect, nextBottomRect, currentBottomRect;

        private SpriteBatch sb;
        public ParallaxScrolling(Game game) : base(game)
        {
            //this.Game.Services.AddService(typeof(IParallaxScrolling));
        }
        public virtual void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            currentBG = this.Game.Content.Load<Texture2D>(TextureName);
            currentOffset = Vector2.Zero;
            DrawRectangles();
        }
        private void DrawRectangles()
        {
            this.currentBottomRect = new Rectangle((int)this.currentOffset.X, (int)this.currentOffset.Y, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);
            this.prevBottomRect = new Rectangle((int)this.currentOffset.X - this.Game.GraphicsDevice.Viewport.Width, (int)this.currentOffset.Y + this.Game.GraphicsDevice.Viewport.Height, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);
            this.nextBottomRect = new Rectangle((int)this.currentOffset.X + this.Game.GraphicsDevice.Viewport.Width, (int)this.currentOffset.Y + this.Game.GraphicsDevice.Viewport.Height, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);

            this.currentRect = new Rectangle((int)this.currentOffset.X, (int)this.currentOffset.Y, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);
            this.prevRect = new Rectangle((int)this.currentOffset.X - this.Game.GraphicsDevice.Viewport.Width, (int)this.currentOffset.Y, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);
            this.nextRect = new Rectangle((int)this.currentOffset.X + this.Game.GraphicsDevice.Viewport.Width, (int)this.currentOffset.Y, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);

            this.prevTopRect = new Rectangle((int)this.currentOffset.X - this.Game.GraphicsDevice.Viewport.Width, (int)this.currentOffset.Y - this.Game.GraphicsDevice.Viewport.Height, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);
            this.currentTopRect = new Rectangle((int)this.currentOffset.X, (int)this.currentOffset.Y-this.Game.GraphicsDevice.Viewport.Height, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);
            this.nextTopRect = new Rectangle((int)this.currentOffset.X + this.Game.GraphicsDevice.Viewport.Width, (int)this.currentOffset.Y - this.Game.GraphicsDevice.Viewport.Height, this.Game.GraphicsDevice.Viewport.Width, this.Game.GraphicsDevice.Viewport.Height);
        }
        public override void Update(GameTime gameTime)
        {
                DrawRectangles();
                MoveBackGround(gameTime);
        }
        private void MoveBackGround(GameTime gameTime)
        {
            this.currentOffset = this.currentOffset + this.Direction * this.scrollSpeed * (gameTime.ElapsedGameTime.Milliseconds / 10);
            //Right Direction -->
            if (this.currentOffset.X > this.Game.GraphicsDevice.Viewport.Width)
            {
                this.currentOffset.X = 0;
            }
            //Left Direction <--
            if (this.currentOffset.X < -this.Game.GraphicsDevice.Viewport.Width)
            {
                this.currentOffset.X = 0;
            }
            if (this.currentOffset.Y > this.Game.GraphicsDevice.Viewport.Height)
            {
                this.currentOffset.Y = 0;
            }
            if (this.currentOffset.Y < -this.Game.GraphicsDevice.Viewport.Height)
            {
                this.currentOffset.Y = 0;
            }
        }
        public virtual void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(this.currentBG, prevRect, Color.White);
            sb.Draw(this.currentBG, currentRect, Color.White);
            sb.Draw(this.currentBG, nextRect, Color.White);

            sb.Draw(this.currentBG, prevTopRect, Color.White);
            sb.Draw(this.currentBG, currentTopRect, Color.White);
            sb.Draw(this.currentBG, nextTopRect, Color.White);

            sb.Draw(this.currentBG, prevBottomRect, Color.White);
            sb.Draw(this.currentBG, currentBottomRect, Color.White);
            sb.Draw(this.currentBG, nextBottomRect, Color.White);
            sb.End();
        }
    }
}
