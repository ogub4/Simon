using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using AudioToolbox;
using System.Threading;
using System.Threading.Tasks;

namespace Simon
{
    partial class LightButton : UIButton
    {
        private UIColor color;
        private NSUrl soundFile;
        private CancellationTokenSource cancelTokenSource;

        public LightButton(IntPtr handle) : base(handle)
        {
            this.BackgroundColor = UIColor.LightGray;
            this.Layer.BorderWidth = 0;
            this.TitleLabel.Text = "";
            this.cancelTokenSource = null;
        }

        public void init(UIColor color, NSUrl soundFile)
        {
            this.color = color;
            this.soundFile = soundFile;
        }

        public void doDisable()
        {
            this.Enabled = false;
        }

        public void doEnable()
        {
            this.Enabled = true;
        }

        public void doLightOn()
        {
            this.BackgroundColor = this.color;
        }

        public void doLightOff()
        {
            this.BackgroundColor = UIColor.LightGray;
        }

        public async void doPush(int term)
        {
            if (this.cancelTokenSource != null)
            {
                this.cancelTokenSource.Cancel();
            }
            doLightOn();
            SystemSound systemSound = new SystemSound(this.soundFile);
            systemSound.PlaySystemSound();

            this.cancelTokenSource = new CancellationTokenSource();

            try 
            {
                await Task.Delay(term, cancelTokenSource.Token);
            }
            catch (OperationCanceledException ex)
            {

            }


            doLightOff();
        }
    }
}
