using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Simon
{
    public enum SimonItemsType { Up = 0, Down = 1, Left = 2, Right = 3 };

    class SimonController
    {
        private ViewController view;
        private Random rnd;
        private int level;
        private int score;
            
        public SimonController(ViewController view)
        {
            this.rnd = new Random();
            this.view = view;
            this.level = 0;
            this.score = 0;
        }



        public void main()
        {
            doGame();
        }

        private SimonItemsType getRandomItem()
        {
            return (SimonItemsType) rnd.Next(4);
        }

        private void doGame()
        {
            // initialize
            List<SimonItemsType> items = new List<SimonItemsType>();
            this.level = 0;
            this.score = 0;
            items.Clear();

            // ゲームオーバーになるまでループ
            for (;this.level <= 10;)
            {
                this.level++;
                items.Add(getRandomItem());

                // Computer's turn
                view.InvokeOnMainThread(() => {
                    view.switchScreenComputerTurn();
                });

                foreach (SimonItemsType item in items)
                {
                    view.InvokeOnMainThread(() => {
                        view.activateButton(item, true);
                    });
                    Thread.Sleep(3000);
#if false
                    view.InvokeOnMainThread(() => {
                        view.activateButton(item, false);
                    });
#endif
                }

                // Player's turn
                view.InvokeOnMainThread(() => {
                    view.switchScreenPlayerTurn();
                });

                view.OnButtonDownEvent += OnButtonDownHandle;
                
                Thread.Sleep(10000);
            }
        }

        private void OnButtonDownHandle(object sender, OnButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
