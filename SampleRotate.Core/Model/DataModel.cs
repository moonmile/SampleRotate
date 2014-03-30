using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRotate.Core.Model
{
    public class DataModel : BindableBase
    {
        private string _ID = "XYZ000";
        public string ID
        {
            get { return _ID; }
            set { this.SetProperty(ref this._ID, value); }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { this.SetProperty(ref this._UserName, value); }
        }
        private int _Score;
        public int Score
        {
            get { return _Score; }
            set { this.SetProperty(ref this._Score, value); }
        }
        private int _Rank;
        public int Rank
        {
            get { return _Rank; }
            set { this.SetProperty(ref this._Rank, value); }
        }
    }
}
