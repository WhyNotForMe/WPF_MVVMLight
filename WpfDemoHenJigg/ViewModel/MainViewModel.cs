using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using WpfDemoHenJigg;
using WpfDemoHenJigg.ViewModel;
using WpfDemoHenJigg.View;
using WpfDemoHenJigg.Service;
using WpfDemoHenJigg.Model;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace WpfDemoHenJigg.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region SearchCmd

        private RelayCommand _searchCmd;

        public RelayCommand SearchCmd
        {
            set { _searchCmd = value; }
            get
            {
                if (_searchCmd != null)
                {
                    return _searchCmd;
                }
                return new RelayCommand(() => SearchCmdExe(), SearchCmdCanExe);
            }
        }

        private bool SearchCmdCanExe()
        {
            if (ItemsCount == 0)
            {
                return true;
            }
            return false;
        }

        private void SearchCmdExe()
        {

            this.QueryStudents();

        }



        #endregion

        #region ResetCmd

        private RelayCommand _resetCmd;

        public RelayCommand ResetCmd
        {
            set { _resetCmd = value; }
            get
            {
                if (_resetCmd != null)
                {
                    return _resetCmd;
                }
                return new RelayCommand(() => ResetCmdExe(), ResetCmdCanExe);
            }
        }

        private bool ResetCmdCanExe()
        {   //TODO 
            if (StuItemsBase.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void ResetCmdExe()
        {
            this.Search = string.Empty;
            ItemsCount = 0;
            this.ReloadItemsView();
        }

        #endregion

        #region AddCmd

        private RelayCommand _addCmd;

        public RelayCommand AddCmd
        {
            set { _addCmd = value; }
            get
            {
                if (_addCmd != null)
                {
                    return _addCmd;
                }
                return new RelayCommand(() => AddCmdExe(), AddCmdCanExe);
            }
        }

        private bool AddCmdCanExe()
        {
            if (ItemsCount == 0)
            {
                return true;
            }
            return false;
        }

        private void AddCmdExe()
        {
            this.AddStudent();
        }


        #endregion

        #region ModifyCmd

        private RelayCommand _modifyCmd;

        public RelayCommand ModifyCmd
        {
            set { _modifyCmd = value; }
            get
            {
                if (_modifyCmd != null)
                {
                    return _modifyCmd;
                }
                return new RelayCommand(() => ModifyCmdExe(), ModifyCmdCanExe);
            }
        }

        private bool ModifyCmdCanExe()
        {
            if (StuItemsView.Count > 0 && ItemsCount == 1)
            {
                return true;
            }
            return false;
        }

        private void ModifyCmdExe()
        {
            this.EditInfo();

        }



        #endregion

        #region DeleteCmd

        private RelayCommand _deleteCmd;

        public RelayCommand DeleteCmd
        {
            set { _deleteCmd = value; }
            get
            {
                if (_deleteCmd != null)
                {
                    return _deleteCmd;
                }
                return new RelayCommand(() => DeleteCmdExe(), DeleteCmdCanExe);
            }
        }

        private bool DeleteCmdCanExe()
        {
            if (ItemsCount > 0)
            {
                return true;
            }
            return false;
        }

        private void DeleteCmdExe()
        {
            this.DeleteStudents();



        }



        #endregion

        #region SelectItemCmd

        private RelayCommand _selectItemCmd;

        public RelayCommand SelectItemCmd
        {
            set { _selectItemCmd = value; }
            get
            {
                if (_selectItemCmd != null)
                {
                    return _selectItemCmd;
                }
                return new RelayCommand(() => SelectItemCmdExe(), SelectItemCmdCanExe);
            }
        }

        private bool SelectItemCmdCanExe()
        {
            if (StuItemsView.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void SelectItemCmdExe()
        {
            this.ItemsCount = this.StuItemsView.Count(i => i.IsSelected == true);
        }

        #endregion

        #region SelectedStuItem

        public StudentItemViewModel SelectedStuItem { get; set; }
        #endregion

        #region StudentItems

        public ObservableCollection<StudentItemViewModel> StuItemsView { get; set; }
        public ObservableCollection<StudentItemViewModel> StuItemsBase { get; set; }

        #endregion

        #region ItemsCount


        private long _itemsCount;

        public long ItemsCount
        {
            get { return _itemsCount; }
            set
            {
                if (_itemsCount == value) { return; }
                _itemsCount = value;
                this.RaisePropertyChanged("ItemsCount");
            }
        }

        #endregion

        #region Search

        private string _search = string.Empty;

        public string Search
        {
            get { return _search; }
            set
            {
                if (_search == value) { return; }
                _search = value;
                this.RaisePropertyChanged("Search");
            }
        }

        #endregion




        public MainViewModel()
        {

            this.LoadStudents();

        }

        private void LoadStudents()
        {
            IStudentsService AllStudents = new LoadStudentsService();
            var stuList = AllStudents.LoadAllStudents();

            if (stuList != null)
            {

                StuItemsView = new ObservableCollection<StudentItemViewModel>();
                StuItemsBase = new ObservableCollection<StudentItemViewModel>();

                stuList.ForEach(stu =>
                    {
                        StudentItemViewModel StudentItem = new StudentItemViewModel();
                        StudentItem.Student = stu;
                        StuItemsBase.Add(StudentItem);
                        StuItemsView.Add(StudentItem);

                    });

            }
            else
            {
                return;
            }


        }

        private void ReloadItemsView()
        {
            StuItemsView.Clear();
            foreach (var stuItem in StuItemsBase)
            {
                StuItemsView.Add(stuItem);
            }
        }

        private void QueryStudents()
        {
            IQueryService stuQuery = new StudentsQueryService();
            var searchResult = stuQuery.QueryStudentItem(StuItemsBase, Search);

            if (searchResult != null)
            {
                StuItemsView.Clear();
                //foreach (var stuItem in searchResult)
                searchResult.ForEach(item =>
                {
                    StuItemsView.Add(item);
                });

            }
            else
            {
                return;
            }

            if (StuItemsView.Count == 0)
            {
                var r = MessageBox.Show("未找到搜索的内容！", "查询提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                if (r == MessageBoxResult.OK)
                {
                    Search = string.Empty;
                }
            }


        }

        private void DeleteStudents()
        {
            var selectedStudents = this.StuItemsView.Where(i => i.IsSelected == true).ToList();

            if (selectedStudents != null)
            {
                var result = MessageBox.Show($"确认删除所选 {ItemsCount} 项内容？", "删除提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    //foreach (var stuItem in selectedStudents)                
                    selectedStudents.ForEach(item =>
                    {
                        StuItemsBase.Remove(item);
                        StuItemsView.Remove(item);
                        ItemsCount--;
                    });
                }

            }

        }

        public void EditInfo()
        {
            if (ItemsCount == 1)
            {
                Student stuInfoView = new Student()
                {
                    Id = SelectedStuItem.Student.Id,
                    Name = SelectedStuItem.Student.Name,
                    Age = SelectedStuItem.Student.Age,
                    Sex = SelectedStuItem.Student.Sex,
                };
                InfoEditView infoEditWindow = new InfoEditView(stuInfoView);
                var dialogResult = infoEditWindow.ShowDialog();

                if (dialogResult.Value)
                {
                    SelectedStuItem.Student = stuInfoView;
                }

            }
        }

        private void AddStudent()
        {
            if (ItemsCount == 0)
            {
                Student stuInfoView = new Student()
                {
                    Id = StuItemsBase.Max(i => i.Student.Id) + 1,
                    Sex = "Male or Female"
                };
                InfoEditView infoEditWindow = new InfoEditView(stuInfoView);
                var dialogResult = infoEditWindow.ShowDialog();

                if (dialogResult.Value)
                {  
                    StudentItemViewModel stuItemVM = new StudentItemViewModel();
                    stuItemVM.Student = stuInfoView;
                    StuItemsBase.Add(stuItemVM);
                    this.ReloadItemsView();
                }
            }

        }

    }
}