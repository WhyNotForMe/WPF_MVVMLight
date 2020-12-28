using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoHenJigg.Model;

namespace WpfDemoHenJigg.ViewModel
{
    public class InfoEditViewModel : ViewModelBase
    {
        #region StuInfo
        private Student _stuInfo;

        public Student StuInfo
        {
            get { return _stuInfo; }
            set
            {
                if (_stuInfo == value) { return; }
                _stuInfo = value;
                this.RaisePropertyChanged("StuInfo");
            }
        }
        #endregion

        #region ConfirmCmd
        private RelayCommand _confirmCmd;

        public RelayCommand ConfirmCmd
        {
            set { _confirmCmd = value; }
            get
            {
                if (_confirmCmd != null)
                {
                    return _confirmCmd;
                }
                return new RelayCommand(() => ConfirmCmdExe(), ConfirmCmdCanExe);
            }
        }

        private bool ConfirmCmdCanExe()
        {   //TODO
            return true;
        }

        private void ConfirmCmdExe()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CancelCmd
        private RelayCommand _cancelCmd;

        public RelayCommand CancelCmd
        {
            set { _cancelCmd = value; }
            get
            {
                if (_cancelCmd != null)
                {
                    return _cancelCmd;
                }
                return new RelayCommand(() => CancelCmdExe(), CancelCmdCanExe);
            }
        }

        private bool CancelCmdCanExe()
        {
            //TODO
            return true;
        }

        private void CancelCmdExe()
        {
            throw new NotImplementedException();
        }

        #endregion

        public InfoEditViewModel()
        {
           
            
        }


    }
}
