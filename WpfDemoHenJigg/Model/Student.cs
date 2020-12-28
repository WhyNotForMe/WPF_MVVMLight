using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace WpfDemoHenJigg.Model
{
    public class Student : ObservableObject
    {
        #region Id属性
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value) { return; }
                _id = value;
                this.RaisePropertyChanged("Id");
            }
        }
        #endregion

        #region Name属性
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) { return; }
                _name = value;
                this.RaisePropertyChanged("Name");
            }
        }
        #endregion

        #region Age属性
        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                if (_age == value) { return; }
                _age = value;
                this.RaisePropertyChanged("Age");
            }
        }

        #endregion

        #region Sex属性
        private string _sex;

        public string Sex
        {
            get { return _sex; }
            set
            {
                if (_sex == value) { return; }
                _sex = value;
                this.RaisePropertyChanged("Sex");
            }
        }

        #endregion

    }


}
