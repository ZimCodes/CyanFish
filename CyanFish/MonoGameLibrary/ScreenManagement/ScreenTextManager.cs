using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.ScreenManagement
{
    //Does NOT DEPEND on ScreenManager, but is prefer if you use it with a ScreenManager
    class ScreenTextManager : DrawableGameComponent
    {
        SpriteBatch sb;
        SpriteFont font;
        public static string Title,Description,Message,Credit = "Hello World!";
        public static Color TitleColor, MSGColor, DescriptionColor = Color.Blue;
        public static Color TitleShadow = Color.MonoGameOrange;
        ////TODO: Fix Values For Vector2 
        //public static Vector2 DescriptionLoc, MessageLoc, TitleLoc;

        public ScreenTextManager(Game game) : base(game)
        {
            ResetText();
        }

        public void ResetText()
        {
            Title = "Hello World!";
            Description = "Hello World!";
            Message = "Hello World!";
            TitleColor = Color.Blue;
            MSGColor = Color.Blue;
            DescriptionColor = Color.Blue;
            TitleShadow = Color.MonoGameOrange;
            
        }
        protected override void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            font = this.Game.Content.Load<SpriteFont>("font");
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.DrawString(font, Description, new Vector2(350, 400), DescriptionColor);
            sb.DrawString(font, Message, new Vector2(79.5f, 121.5f), Color.Black);
            sb.DrawString(font, Message, new Vector2(80, 120), MSGColor);
            sb.DrawString(font, Title, new Vector2(350, 83), TitleShadow, 0, new Vector2(0, 0), 2, 0, 0);
            sb.DrawString(font, Title, new Vector2(347, 80), TitleColor, 0, new Vector2(0, 0), 2, 0, 0);
            sb.DrawString(font, Credit, new Vector2(15, this.GraphicsDevice.Viewport.Height - 50), Color.WhiteSmoke, 0, new Vector2(0, 0), 1, 0, 0);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
