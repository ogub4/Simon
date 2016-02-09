using System;
using System.Threading;
using System.Collections.Generic;

using UIKit;

namespace Simon
{
    public partial class ViewController : UIViewController
    {
        private SimonController controller;
        private List<LightButton> buttons;

        public ViewController(IntPtr handle) : base(handle)
        {
            this.buttons = new List<LightButton>();
            this.controller = new SimonController(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            initControl();

            Thread thread = new Thread(controller.main);
            thread.Start();
        }

        public void switchScreenComputerTurn()
        {
            foreach(LightButton button in buttons)
            {
                button.doDisable();
            }

            labelStatus.Text = "Computer's turn.";
        }

        public void switchScreenPlayerTurn()
        {
            foreach (LightButton button in buttons)
            {
                button.doEnable();
            }

            labelStatus.Text = "Player's turn";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void initControl()
        {
            labelStatus.Text = "";
            buttons.Add(btnUp);
            buttons.Add(btnDown);
            buttons.Add(btnLeft);
            buttons.Add(btnRight);
        }

    }
}