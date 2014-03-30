using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SampleRotate.Core.Model;

namespace SampleRotate.iOS
{
	public partial class SampleRotate_iOSViewController : UIViewController
	{
		public SampleRotate_iOSViewController (IntPtr handle) : base (handle)
		{
		}

        private DataModel _model;
        
        public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
            // データ
            _model = new DataModel
            {
                ID = "X20140330",
                UserName = "Tomoaki",
                Score = 100,
                Rank = 10
            };
            UpdateData();
        }

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

		bool isShowingLandscaeView ;
		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			/*
			isShowingLandscaeView = NO ;
			[[UIDevice currentDevice] beginGeneratingDeviceOrientationNotifications];
			[[NSNotificationCenter defaultCenter] addObserver:self
				selector:@selector(orientationChanged:)
				name:UIDeviceOrientationDidChangeNotification
				object:nil];
				*/
			this.isShowingLandscaeView = false;
			UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications ();
			NSNotificationCenter.DefaultCenter.AddObserver (
				"UIDeviceOrientationDidChangeNotification",
				orientationChanged);
		}
		void orientationChanged( NSNotification obj ) 
		{
			var deviceOrientation = UIDevice.CurrentDevice.Orientation;
			if (deviceOrientation == UIDeviceOrientation.LandscapeLeft ||
				deviceOrientation == UIDeviceOrientation.LandscapeRight) {
				if (isShowingLandscaeView == false) {
					this.PerformSegue ("LandView", this);
					isShowingLandscaeView = true;
				}
			} else if (deviceOrientation == UIDeviceOrientation.Portrait ||
				deviceOrientation == UIDeviceOrientation.PortraitUpsideDown) {
				if (isShowingLandscaeView == true) {
					this.DismissViewController (false, null);
					isShowingLandscaeView = false;
				}
			}
		}

        /// <summary>
        /// 手動でバインド
        /// </summary>
        private void UpdateData()
        {
            this.textID.Text = _model.ID;
            this.textUserName.Text = _model.UserName;
            this.textScore.Text = _model.Score.ToString();
            this.textRank.Text = _model.Rank.ToString();
        }

	}
}

