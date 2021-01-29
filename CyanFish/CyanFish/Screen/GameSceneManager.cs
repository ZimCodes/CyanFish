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
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{

    public class GameSceneManager:DrawableGameComponent
    {
        SoundManager sm;
        private InputHandler input;
        private SwitchScreenManager switchScreen;
        private GameScene s;
        public GameSceneManager(Game game):base(game)
        {
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            if (input == null)
            {
                input = new InputHandler(game);
                this.Game.Components.Add(input);
            }
            switchScreen = (SwitchScreenManager)game.Services.GetService(typeof(IScreenSwitch));
            if (switchScreen == null)
            {
                switchScreen = new SwitchScreenManager(game);
                this.Game.Components.Add(switchScreen);
            }
            sm = (SoundManager)this.Game.Services.GetService(typeof(ISoundManager));
            if (sm == null)
            {
                sm = new SoundManager(this.Game);
                this.Game.Components.Add(sm);
            }
        }
        /// <summary>
        /// Add Screens Here!
        /// </summary>
        public override void Initialize()
        {
            //Add Scene Order: First in First Out
            AddScreens(GameScreen.IntroScreen);
            AddScreens(GameScreen.PlayScreen);
            AddScreens(GameScreen.TutorialScreen);
            AddScreens(GameScreen.EndScreen);
            sm.Initialize();
            base.Initialize();
            sm.bgInstance.Play();
            sm.bgInstance.IsLooped = true;
            ScoreManager.MuteMSG = "LShift toggle Music";
        }
        public override void Update(GameTime gameTime)
        {
            HandleSound();
            for (int i = 0; i < switchScreen.Screens.Count; i++)
            {
                switchScreen.Screens[i].Update(gameTime);
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < switchScreen.Screens.Count; i++)
            {
                switchScreen.Screens[i].Draw(gameTime);
            }
            base.Draw(gameTime);
        }
        private void HandleSound()
        {
            if (input.KeyboardState.WasKeyPressed(Keys.LeftShift) && sm.bgInstance.State == Microsoft.Xna.Framework.Audio.SoundState.Stopped)
            {
                sm.bgInstance.Play();
                sm.bgInstance.IsLooped = true;
            }
            else if (input.KeyboardState.WasKeyPressed(Keys.LeftShift) && sm.bgInstance.State == Microsoft.Xna.Framework.Audio.SoundState.Playing)
            {
                sm.bgInstance.IsLooped = false;
                sm.bgInstance.Stop();
            }
        }
        /// <summary>
        /// Adds a screen into a List
        /// </summary>
        /// <param name="screen"></param>
        private void AddScreens(GameScreen screen)
        {
            switch (screen)
            {
                case GameScreen.PlayScreen:
                    s = new PlayScreen(this.Game);
                    s.Initialize();
                    switchScreen.Push(s);
                    break;
                case GameScreen.IntroScreen:
                    s = new IntroScreen(this.Game);
                    s.Initialize();
                    switchScreen.Push(s);
                    break;
                case GameScreen.TutorialScreen:
                    s = new TutorialScreen(this.Game);
                    s.Initialize();
                    switchScreen.Push(s);
                    break;
                case GameScreen.EndScreen:
                    s = new EndScreen(this.Game);
                    s.Initialize();
                    switchScreen.Push(s);
                    break;
            }
        }
    }
}
