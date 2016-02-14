using System;
using System.Threading;
using System.Collections.Generic;

using UIKit;
using Foundation;
using AudioToolbox;

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
            btnUp.Color = UIColor.Blue;
            btnDown.Color = UIColor.Green;
            btnRight.Color = UIColor.Yellow;
            btnLeft.Color = UIColor.Red;

            buttons.Add(btnUp);
            buttons.Add(btnDown);
            buttons.Add(btnLeft);
            buttons.Add(btnRight);
        }

        public void activateButton(SimonItems item, bool activateFlag)
        {
            LightButton button;
            NSUrl url;
            switch (item)
            {
                case SimonItems.Up:
                    button = btnUp;
                    url = NSUrl.FromFilename("Sounds/pianoC.mp3");
                    break;

                case SimonItems.Down:
                    button = btnDown;
                    url = NSUrl.FromFilename("Sounds/pianoD.mp3");
                    break;

                case SimonItems.Right:
                    button = btnRight;
                    url = NSUrl.FromFilename("Sounds/pianoE.mp3");
                    break;

                case SimonItems.Left:
                    button = btnLeft;
                    url = NSUrl.FromFilename("Sounds/pianoF.mp3");
                    break;
                default:
                    button = btnUp;
                    url = NSUrl.FromFilename("Sounds/pianoC.mp3");
                    break;
            }
            if (activateFlag)
            {
                button.doLightOn();
                SystemSound systemSound = new SystemSound(url);
                systemSound.PlaySystemSound();
            }
            else
            {
                button.doLightOff();
            }

        }
    }
}