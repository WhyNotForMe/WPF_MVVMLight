using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoCrazyElephant.Model;
using GalaSoft.MvvmLight;

namespace WpfDemoCrazyElephant.ViewModel
{
    public class DishItemViewModel : ViewModelBase
    {
        public Dish Dish { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected == value) { return; }
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

    }
}
