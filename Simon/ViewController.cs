using System;
using System.Threading;
using System.Collections.Generic;

using UIKit;
using Foundation;
using AudioToolbox;

namespace Simon
{
    public class OnButtonEventArgs :EventArgs
    {
        public SimonItemsType item;
        public OnButtonEventArgs(SimonItemsType item)
        {
            this.item = item;
        }
    }

    public partial class ViewController : UIViewController
    {
        private SimonController controller;
        private List<LightButton> buttons;

        public delegate void OnButtonDown(object sender, OnButtonEventArgs e);
        public event OnButtonDown OnButtonDownEvent;

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
            btnUp.init(UIColor.Blue, new NSUrl("Sounds/pianoC.mp3"));
            btnDown.init(UIColor.Green, new NSUrl("Sounds/pianoD.mp3"));
            btnRight.init(UIColor.Yellow, new NSUrl("Sounds/pianoE.mp3"));
            btnLeft.init(UIColor.Red, new NSUrl("Sounds/pianoF.mp3"));

            buttons.Add(btnUp);
            buttons.Add(btnDown);
            buttons.Add(btnLeft);
            buttons.Add(btnRight);
        }

        public void activateButton(SimonItemsType item, bool activateFlag)
        {
            LightButton button;
            switch (item)
            {
                case SimonItemsType.Up:
                    button = btnUp;
                    break;

                case SimonItemsType.Down:
                    button = btnDown;
                    break;

                case SimonItemsType.Right:
                    button = btnRight;
                    break;

                case SimonItemsType.Left:
                    button = btnLeft;
                    break;
                default:
                    button = btnUp;
                    break;
            }
            if (activateFlag)
            {
                button.doPush(3000);
            }
            else
            {
//                button.doLightOff();
            }
        }

        partial void OnUpButtonDown(Simon.LightButton sender)
        {
            NoticeButtonDown(sender, SimonItemsType.Up);
        }

        partial void OnLeftButtonDown(Simon.LightButton sender)
        {
            NoticeButtonDown(sender, SimonItemsType.Left);
        }

        partial void OnRightButtonDown(Simon.LightButton sender)
        {
            NoticeButtonDown(sender, SimonItemsType.Right);
        }

        partial void OnDownButtonDown(Simon.LightButton sender)
        {
            NoticeButtonDown(sender, SimonItemsType.Down);
        }

        private void NoticeButtonDown(Simon.LightButton sender, SimonItemsType item)
        {
            sender.doPush(1000);

            if (OnButtonDownEvent != null)
            {
                OnButtonDownEvent(this, new OnButtonEventArgs(item));
            }

        }

        public void setLevel(int level)
        {
            this.labelLevel.Text = string.Format("{0}", level);
        }
    }
}