using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Simon
{
    partial class LightButton : UIButton
    {
        private UIColor color;

        public LightButton(IntPtr handle) : base(handle)
        {
            this.BackgroundColor = UIColor.LightGray;
            this.Layer.BorderWidth = 0;
            this.TitleLabel.Text = "";
        }

        public UIColor Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
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
    }
}
