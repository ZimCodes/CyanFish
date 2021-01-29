/*  CyanFish is an open-source 2D 'collect them all' game created in using MonoGame.
      Copyright (C) 2018  ZimCodes

      This program is free software: you can redistribute it and/or modify
      it under the terms of the GNU General Public License as published by
      the Free Software Foundation, either version 3 of the License, or
      (at your option) any later version.

      This program is distributed in the hope that it will be useful,
      but WITHOUT ANY WARRANTY; without even the implied warranty of
      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      GNU General Public License for more details.*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.CollisionData;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    class PlayScreen:GameScene
    {
        public bool isPaused;
        SharkSpawner shark;
        PlayerController fish;
        BombSpawner bomb;
        ScoreManager sm;
        SwitchScreenManager switchScreen;
        InputHandler input;
        public PlayScreen(Game game):base(game)
        {
            State = GameScreen.PlayScreen;
            fish = new PlayerController(game, this);
            this.Game.Components.Add(fish);
            shark = new SharkSpawner(game,this,fish);
            this.Game.Components.Add(shark);
            bomb = new BombSpawner(game,this,fish);
            this.Game.Components.Add(bomb);
            sm = new ScoreManager(game);
            this.Game.Components.Add(sm);
            
            switchScreen = (SwitchScreenManager)this.Game.Services.GetService(typeof(IScreenSwitch));
            if (switchScreen == null)
            {
                switchScreen = new SwitchScreenManager(this.Game);
                this.Game.Components.Add(switchScreen);
            }
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            if (input == null)
            {
                input = new InputHandler(game);
                this.Game.Components.Add(input);
            }
        }
        protected override void LoadContent()
        {
            this.SceneTexture = this.Game.Content.Load<Texture2D>("CoralReef");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (switchScreen.Screens[0] == this)
            {
                PauseGame();
            }
            if (this.Enabled)
            {
                sm.Enabled = true;
                ScoreText();
                bomb.Update(gameTime);
                fish.Update(gameTime);
                shark.Update(gameTime);
                base.Update(gameTime);
            }
            else if(!isPaused)
            {
                fish.Location = fish.ResetStartLocation();
            }
        } 
        public override void Draw(GameTime gameTime)
        {
            if (this.Visible)
            {
                sm.Visible = true;
                base.Draw(gameTime);
            }
        }
        private void ScoreText()
        {
            if (ScoreManager.Score > ScoreManager.HiScore)
            {
                ScoreManager.HiScore = ScoreManager.Score;
            }
        }
        
        private void PauseGame()
        {
            if (input.KeyboardState.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space) && !isPaused)
            {
                ScoreManager.PauseMSG = "Game Paused";
                this.isPaused = true;
                this.Enabled = false;
            }
            else if (input.KeyboardState.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space) && isPaused)
            {
                ScoreManager.PauseMSG = "";
                this.isPaused = false;
                this.Enabled = true;
            }
            if (input.KeyboardState.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter) && !isPaused)
            {
                ScoreManager.PauseMSG = "Game Paused";
                this.isPaused = true;
                this.Enabled = false;
            }
            else if (input.KeyboardState.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter) && isPaused)
            {
                ScoreManager.PauseMSG = "";
                this.isPaused = false;
                this.Enabled = true;
            }
        }
    }
}
