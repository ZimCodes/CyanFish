using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Custom_Classes
{
    public class Button : DrawableAnimatableSprite
    {
        public enum BtnState { OnHover, Active, InActive,Click }
        public BtnState State; 
        InputHandler input;
        private SpriteAnimation buttonTexture; 
        public SpriteAnimation ButtonTexture {
            get {
                return buttonTexture;
            }
            set
            {
                this.buttonTexture = value;
            }
        }
        public Button(Game game):base(game)
        {
            input = (InputHandler)this.Game.Services.GetService(typeof(IInputHandler));
            if (input == null)
            {
                input = new InputHandler(this.Game);
                this.Game.Components.Add(input);
            }
            this.State = BtnState.InActive;
        }
        protected override void LoadContent()
        {
            
            base.LoadContent();
            //this.Origin = new Vector2(this.spriteAnimationAdapter.CurrentTexture.Width / 2,this.spriteAnimationAdapter.CurrentTexture.Height/2 );
        }
        public override void Update(GameTime gameTime)
        {
            //UnComment for Default Functionalities States
            //if (this.ButtonClick(MouseButtons.LeftButton))
            //{

            //    this.State = BtnState.Click;
            //}
            //else if (this.Hover(MouseButtons.LeftButton))
            //{
            //    this.State = BtnState.OnHover;
            //}
            //else if (this.ButtonHolding(MouseButtons.LeftButton))
            //{
            //    this.State = BtnState.Active;
            //}
            //else
            //{
            //    this.State = BtnState.InActive;
            //}
            base.Update(gameTime);
        }
        /// <summary>
        ///  Tells you if Button was clicked
        /// </summary>
        /// <param name="button">The button you want to read</param>
        /// <returns>returns whether or not Button was clicked</returns>
        protected bool ButtonClick(MouseButtons button)
        {
            
            if (input.MouseState.WasMouseBtnPressed(button) && WithinHotSpot())
            {
                
                return true;
            }
            
            return false;
        }
        /// <summary>
        /// Tells if the user is holding a mouse button on the button texture 
        /// </summary>
        /// <param name="button">The button you want to read</param>
        /// <returns>returns whether or not Button is being held down</returns>
        protected bool ButtonHolding(MouseButtons button)
        {

            if (input.MouseState.IsMouseDown(button) && WithinHotSpot())
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Generates a hotspot on a button texture
        /// </summary>
        /// <returns></returns>
        private bool WithinHotSpot()
        {
            Vector2 starthotspot = new Vector2(this.Location.X, this.Location.Y);
            Vector2 endhotspot = new Vector2(this.Location.X+ this.spriteAnimationAdapter.CurrentLocationRect.Width, this.Location.Y+ this.spriteAnimationAdapter.CurrentLocationRect.Height);
            if (input.MouseState.mouseState.Position.X >= starthotspot.X && input.MouseState.mouseState.Position.X <= endhotspot.X
                && input.MouseState.mouseState.Position.Y >= starthotspot.Y && input.MouseState.mouseState.Position.Y <= endhotspot.Y)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Tells whether or not the mouse if hovering over a button texture
        /// </summary>
        /// <param name="button">The button you want to read</param>
        /// <returns></returns>
        protected bool Hover()
        {
            if (WithinHotSpot())
            {
                return true;
            }
            return false;
        }
    }
}
