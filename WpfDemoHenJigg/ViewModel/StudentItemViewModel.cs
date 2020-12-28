using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoHenJigg.Model;

namespace WpfDemoHenJigg.ViewModel
{
    public class StudentItemViewModel : ViewModelBase
    {
        #region Student属性
        private Student _student;

        public Student Student
        {
            get { return _student; }
            set
            {
                if (_student == value) { return; }
                _student = value;
                this.RaisePropertyChanged("Student");
            }
        }

        #endregion

        #region IsSelected属性
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) { return; }
                _isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

        #endregion

    }
}
