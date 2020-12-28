using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoCalcAdd.Client.View;
using WpfDemoCalcAdd.Client.Command;
using Microsoft.Win32;


namespace WpfDemoCalcAdd.Client.ViewModel
{
    class MainWindowViewModel : NotificationObject
    {
        private double input1;

        public double Input1
        {
            get { return input1; }
            set
            {
                if (input1 == value) { return; }
                input1 = value;
                this.RaisePropertyChanged("Input1");
            }
        }

        private double input2;

        public double Input2
        {
            get { return input2; }
            set
            {
                if (input2 == value) { return; }
                input2 = value;
                this.RaisePropertyChanged("Input2");
            }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                if (result == value) { return; }
                result = value;
                this.RaisePropertyChanged("Result");
            }
        }

        public DelegateCommand CommandAdd { get; set; }
        public DelegateCommand CommandSave { get; set; }


        private void Add(object obj)
        {
            this.Result = this.Input1 + this.Input2;
        }

        private void Save(object obj)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt|所有文件|*.*";
            sfd.RestoreDirectory = true;
            sfd.ShowDialog();
        }

        public MainWindowViewModel()
        {
            this.CommandAdd = new DelegateCommand();
            this.CommandAdd.ActionExecute=new Action<object>(Add);

            this.CommandSave = new DelegateCommand();
            this.CommandSave.ActionExecute = Save;
        }

    }
}
