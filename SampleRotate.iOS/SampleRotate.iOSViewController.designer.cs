// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SampleRotate.iOS
{
	[Register ("SampleRotate_iOSViewController")]
	partial class SampleRotate_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel textID { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel textRank { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel textScore { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel textUserName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (textID != null) {
				textID.Dispose ();
				textID = null;
			}

			if (textUserName != null) {
				textUserName.Dispose ();
				textUserName = null;
			}

			if (textScore != null) {
				textScore.Dispose ();
				textScore = null;
			}

			if (textRank != null) {
				textRank.Dispose ();
				textRank = null;
			}
		}
	}
}
