using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFish
{
    public interface IScreenSwitch
    {
        void NextScreen();
        void PreviousScreen();
        void Push(GameScene screen);
    }
    //Need To Create a ScreenManager
    public class SwitchScreenManager:GameComponent, IScreenSwitch
    {
        public List<GameScene> Screens = new List<GameScene>();
        private List<GameScene> ResetOrder = new List<GameScene>();
        ///Counter to amount of times you can next screen(use Count variant method)
        private int LimitScreenNext = 1;
        ///Max times you can go to next Screen(use Count variants method)
        public int LimitScreenMax = 3;
        ///True if number of Nexts has been reached
        public bool LimitEnded = false;
        public SwitchScreenManager(Game game) : base(game)
        {
            game.Services.AddService(typeof(IScreenSwitch), this);
        }
        /// <summary>
        /// Go To Next Screen in the List
        /// </summary>
        public void NextScreen()
        {
            //1234
            //234 1
            //2341
            GameScene temp;
            temp = Screens[0];
            Screens.Remove(Screens[0]);
            Screens.Add(temp);
            LoadScreen();
        }
        /// <summary>
        /// NextScreen() variant; Subtracts Next limit counter 
        /// </summary>
        public void NextScreenCount()
        {
            //1234
            //234 1
            //2341
            LimitScreenNext++;
            GameScene temp;
            temp = Screens[0];
            Screens.Remove(Screens[0]);
            Screens.Add(temp);
            if (LimitScreenNext <= 1)
            {
                LimitScreenNext = 1;
            }
            LoadScreen();
        }
        /// <summary>
        /// Go to Previous Screen in the List
        /// </summary>
        public void PreviousScreen()
        {
            //1234
            //123 4
            //4123
            GameScene temp;
            temp = Screens[Screens.Count - 1];
            Screens.Remove(Screens[Screens.Count - 1]);
            Screens.Insert(0, temp);
            LoadScreen();
        }
        /// <summary>
        ///PreviousScreen() Variant: adds to the Next limit Counter   
        /// </summary>
        public void PreviousScreenCount()
        {
            //1234
            //123 4
            //4123
            if (LimitScreenNext < LimitScreenMax)
            {
                LimitScreenNext--;
                GameScene temp;
                temp = Screens[Screens.Count - 1];
                Screens.Remove(Screens[Screens.Count - 1]);
                Screens.Insert(0, temp);
                LoadScreen();
            }
            else
            {
                LoadScreen();
                //Do Nothing
            }

        }
        /// <summary>
        /// Adds Screens to List
        /// </summary>
        /// <param name="screen"></param>
        public void Push(GameScene screen)
        {
            Screens.Add(screen);
            ResetOrder.Add(screen);
            LoadScreen();
        }
        /// <summary>
        /// Relocates a screen in the list
        /// </summary>
        /// <param name="loc">Place you want to relocate</param>
        /// <param name="screen">The Screen You want inserted</param>
        public void ScreenPlace(int loc, int screen)
        {
            //1234
            //124 
            //3124
            GameScene temp = Screens[screen];
            Screens.Remove(temp);
            Screens.Insert(loc, temp);
            for (int i = 0; i < Screens.Count;i++)
            {
                if (i == screen)
                {
                    Screens[i].Visible = Screens[i].Enabled = true;
                }
                else
                {
                    Screens[i].Visible = Screens[i].Enabled = false;
                }
            }
            LoadScreen();
        }
        /// <summary>
        /// Resets the position of the screens based on the order they were pushed
        /// </summary>
        public void ResetPosition()
        {
            Screens.Clear();
            foreach (GameScene gc in ResetOrder)
            {
                Screens.Add(gc);
            }
            LoadScreen();
        }
        /// <summary>
        /// Resets the position of the screens based on the order they were pushed;Resets the Next Counter 
        /// </summary>
        public void ResetPositionCount()
        {
            LimitScreenNext = 1;
            Screens.Clear();
            foreach (GameScene gc in ResetOrder)
            {
                Screens.Add(gc);
            }
            LoadScreen();
        }
        /// <summary>
        /// resets the counter for limiting the number of times to click the next screen 
        /// </summary>
        /// <param name="reset">Want to Reset Next Counter?</param>
        public void WantToResetScreenLimitCounter(bool reset)
        {
            bool Reset = reset;
            if (Reset)
            {
                LimitScreenNext = 1;
                Reset = false;
            }
            LoadScreen();
        }
        public override void Update(GameTime gameTime)
        {
            if (LimitScreenNext >= LimitScreenMax)
            {
                LimitEnded = true;
            }
            else
            {
                LimitEnded = false;
            }
            base.Update(gameTime);
        }
        
        /// <summary>
        /// Activates the Screen that is currently on top of the List
        /// </summary>
        private void LoadScreen()
        {
            if (Screens.Count > 1)
            {
                for (int i = 0; i < Screens.Count; i++)
                {
                    if (i == 0)
                    {
                        Screens[0].Enabled = Screens[0].Visible = true;
                    }
                    else
                    {
                        Screens[i].Enabled = Screens[i].Visible = false;
                    }
                }
            }

        }

    }
}
