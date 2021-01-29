using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class Player:DrawableAnimatableSprite
    {
        protected SpriteAnimation moveRight, moveLeft, currentAnimation;
        public Rectangle rectCollision;
        public Player(Game game):base(game)
        {

        }
        protected override void LoadContent()
        {
            this.moveRight = new SpriteAnimation("MoveRight","MoveRight",5,2,2);
            this.moveLeft = new SpriteAnimation("MoveLeft", "MoveLeft", 5, 2, 2);
            this.currentAnimation = this.moveLeft;
            spriteAnimationAdapter.AddAnimation(this.currentAnimation);
            this.Location = new Vector2(this.Game.GraphicsDevice.Viewport.Width/2,this.Game.GraphicsDevice.Viewport.Height/2);
            this.Direction = Vector2.Zero;
            this.Speed = 85f;
            
            base.LoadContent();
            rectCollision = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteAnimationAdapter.CurrentLocationRect.Width, this.spriteAnimationAdapter.CurrentLocationRect.Height);
        }
        public override void Update(GameTime gameTime)
        {
           
            AnimationSwitch();
            OutOfBounds();
            base.Update(gameTime);
            
        }
        private void AnimationSwitch()
        {
            if (this.Direction.X == 1)
            {
                if (this.currentAnimation == this.moveRight)
                {
                    spriteAnimationAdapter.ResumeAmination(this.currentAnimation);
                }
                else
                {
                    spriteAnimationAdapter.RemoveAnimation(this.currentAnimation);
                    this.currentAnimation = this.moveRight;
                    spriteAnimationAdapter.AddAnimation(this.currentAnimation);
                }
            }
            if (this.Direction.X == -1)
            {
                if (this.currentAnimation == this.moveLeft)
                {
                    spriteAnimationAdapter.ResumeAmination(this.currentAnimation);
                }
                else
                {
                    spriteAnimationAdapter.RemoveAnimation(this.currentAnimation);
                    this.currentAnimation = this.moveLeft;
                    spriteAnimationAdapter.AddAnimation(this.currentAnimation);
                }
            }
        }
        private void OutOfBounds() {
            if (this.Location.X < 0)
            {
                this.Location.X = 0;
            }
            if (this.Location.X > this.GraphicsDevice.Viewport.Width- this.spriteAnimationAdapter.CurrentLocationRect.Width)
            {
                this.Location.X = this.GraphicsDevice.Viewport.Width- this.spriteAnimationAdapter.CurrentLocationRect.Width;
            }
            if (this.Location.Y < 0)
            {
                this.Location.Y = 0;
            }
            if (this.Location.Y > this.GraphicsDevice.Viewport.Height - this.spriteAnimationAdapter.CurrentLocationRect.Height)
            {
                this.Location.Y = this.GraphicsDevice.Viewport.Height - this.spriteAnimationAdapter.CurrentLocationRect.Height;
            }
        }
        public Vector2 ResetStartLocation() {
            return new Vector2(this.Game.GraphicsDevice.Viewport.Width / 2, this.Game.GraphicsDevice.Viewport.Height / 2);
        }
    }
}
