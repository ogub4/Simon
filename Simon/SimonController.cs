using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Simon
{
    class SimonController
    {
        private ViewController view;
        enum SimonItems { Up = 0, Down = 1, Left = 2, Right = 3 };
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
        }
    }
}
