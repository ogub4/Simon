using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Simon
{
    public enum SimonItems { Up = 0, Down = 1, Left = 2, Right = 3 };

    class SimonController
    {
        private ViewController view;
        private List<int> items;
        private Random rnd;
            
        public SimonController(ViewController view)
        {
            this.rnd = new Random();
            this.items = new List<int>();
            this.view = view;
        
        }



        public void main()
        {
            view.InvokeOnMainThread(() => {
                view.switchScreenComputerTurn();
            });

            doGame();
        }

        private int getRandomItem()
        {
            return rnd.Next(4);
        }

        private void doGame()
        {
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());
            this.items.Add(getRandomItem());

            foreach (SimonItems item in this.items)
            {

                view.InvokeOnMainThread(() => {
                    view.activateButton(item, true);
                });
                Thread.Sleep(3000);
                view.InvokeOnMainThread(() => {
                    view.activateButton(item, false);
                });
            }
        }
    }
}
