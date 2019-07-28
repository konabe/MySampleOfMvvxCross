using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TipCalc.Core.Models
{
    public class Store : MvxNotifyPropertyChanged
    {
        private Item _item = new Item();
        public Item Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }
    }
}
