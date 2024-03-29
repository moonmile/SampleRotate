﻿using SampleRotate.Win8.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SampleRotate.Core.Model;
using Windows.Graphics.Display;


// 基本ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234237 を参照してください

namespace SampleRotate.Win8
{
    /// <summary>
    /// 多くのアプリケーションに共通の特性を指定する基本ページ。
    /// </summary>
    public sealed partial class BasicPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// これは厳密に型指定されたビュー モデルに変更できます。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper は、ナビゲーションおよびプロセス継続時間管理を
        /// 支援するために、各ページで使用します。
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        private DataModel _model;


        public BasicPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
        /// 再作成する場合は、保存状態も指定されます。
        /// </summary>
        /// <param name="sender">
        /// イベントのソース (通常、<see cref="NavigationHelper"/>)>
        /// </param>
        /// <param name="e">このページが最初に要求されたときに
        /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたナビゲーション パラメーターと、
        /// 前のセッションでこのページによって保存された状態の辞書を提供する
        /// セッション。ページに初めてアクセスするとき、状態は null になります。</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// アプリケーションが中断される場合、またはページがナビゲーション キャッシュから破棄される場合、
        /// このページに関連付けられた状態を保存します。値は、
        /// <see cref="SuspensionManager.SessionState"/> のシリアル化の要件に準拠する必要があります。
        /// </summary>
        /// <param name="sender">イベントのソース (通常、<see cref="NavigationHelper"/>)</param>
        /// <param name="e">シリアル化可能な状態で作成される空のディクショナリを提供するイベント データ
        ///。</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper の登録

        /// このセクションに示したメソッドは、NavigationHelper がページの
        /// ナビゲーション メソッドに応答できるようにするためにのみ使用します。
        /// 
        /// ページ固有のロジックは、
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// および <see cref="GridCS.Common.NavigationHelper.SaveState"/> のイベント ハンドラーに配置する必要があります。
        /// LoadState メソッドでは、前のセッションで保存されたページの状態に加え、
        /// ナビゲーション パラメーターを使用できます。

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void pageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            // バインド
            _model = new DataModel
            {
                ID = "X20140330",
                UserName = "Tomoaki",
                Score = 100,
                Rank = 10
            };
            this.DataContext = _model;

        }

        /// <summary>
        /// レイアウト変更時
        /// 回転のみ対応
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageRoot_LayoutUpdated(object sender, object e)
        {
            DisplayInformation displayInfo = DisplayInformation.GetForCurrentView();
            switch (displayInfo.CurrentOrientation)
            {
                // 横置き
                case DisplayOrientations.Landscape:
                case DisplayOrientations.LandscapeFlipped:
                    VisualStateManager.GoToState(this, "Landscape", true);
                    break;
                // 縦置き
                case DisplayOrientations.Portrait:
                case DisplayOrientations.PortraitFlipped:
                    VisualStateManager.GoToState(this, "Portrait", true);
                    break;
            }
        }
    }
}
