using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SampleRotate.Core.Model;

namespace SampleRotate.Android
{
    [Activity(Label = "SampleRotate.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        private DataModel _model;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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

        /// <summary>
        /// 手動でバインド
        /// </summary>
        private void UpdateData()
        {
            FindViewById<TextView>(Resource.Id.textViewID).Text = _model.ID;
            FindViewById<TextView>(Resource.Id.textViewUserName).Text = _model.UserName;
            FindViewById<TextView>(Resource.Id.textViewScore).Text = _model.Score.ToString();
            FindViewById<TextView>(Resource.Id.textViewRank).Text = _model.Rank.ToString();
        }
    }
}

