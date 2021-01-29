using Microsoft.Xna.Framework;
using MonoGameLibrary.CollisionData;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
   
    class PlayerController:Player
    {
        InputHandler input;
        PlayScreen playscreen;
        public PlayerController(Game game,PlayScreen play):base(game)
        {
            input = (InputHandler)this.Game.Services.GetService(typeof(IInputHandler));
            if (input == null)
            {
                input = new InputHandler(this.Game);
                this.Game.Components.Add(input);
            }
            playscreen = play;
        }
        public override void Update(GameTime gameTime)
        {
            if (playscreen.Enabled)
            {
                this.Location = this.Location + this.Direction * ((lastUpdateTime / 1000) * this.Speed);
                Movement();
                rectCollision = new Rectangle((int)this.Location.X, (int)this.Location.Y, this.spriteAnimationAdapter.CurrentLocationRect.Width,this.spriteAnimationAdapter.CurrentLocationRect.Height);
                base.Update(gameTime);
            }
        }
        public override void Draw(GameTime gameTime)
        {
            if (playscreen.Visible)
            {
                base.Draw(gameTime);
            }
            
        }
        public void Movement()
        {
            this.Direction = Vector2.Zero;
            if (input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left) || input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
            {
                this.Direction.X = -1;
            }
            if (input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right) || input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            {
                this.Direction.X = 1;
            }
            if (input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up) || input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                this.Direction.Y = -1;
            }
            if (input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down) || input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
            {
                this.Direction.Y = 1;
            }
        }
    }
}
