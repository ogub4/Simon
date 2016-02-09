// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Simon
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Simon.LightButton btnDown { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Simon.LightButton btnLeft { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Simon.LightButton btnRight { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Simon.LightButton btnUp { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelStatus { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnDown != null) {
				btnDown.Dispose ();
				btnDown = null;
			}
			if (btnLeft != null) {
				btnLeft.Dispose ();
				btnLeft = null;
			}
			if (btnRight != null) {
				btnRight.Dispose ();
				btnRight = null;
			}
			if (btnUp != null) {
				btnUp.Dispose ();
				btnUp = null;
			}
			if (labelStatus != null) {
				labelStatus.Dispose ();
				labelStatus = null;
			}
		}
	}
}
