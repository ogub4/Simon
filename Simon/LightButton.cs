using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Simon
{
    partial class LightButton : UIButton
    {
        public LightButton(IntPtr handle) : base(handle)
        {
            this.BackgroundColor = UIColor.LightGray;
            this.Layer.BorderWidth = 1;
            this.TitleLabel.Text = "";
        }

        public void doDisable()
        {
            this.Enabled = false;
        }

        public void doEnable()
        {
            this.Enabled = true;
        }

        public void doLight()
        {
            this.BackgroundColor = UIColor.Red;
        }
    }
}
