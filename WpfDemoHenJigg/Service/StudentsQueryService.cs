using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfDemoHenJigg.ViewModel;

namespace WpfDemoHenJigg.Service
{
    public class StudentsQueryService : IQueryService
    {


        public List<StudentItemViewModel> QueryStudentItem(ObservableCollection<StudentItemViewModel> stuList, string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("请输入查询内容！","查询提示",MessageBoxButton.OK,MessageBoxImage.Warning);
                return null;
            }
            return stuList.Where(i => i.Student.Name.Contains(search)).ToList();
        }
    }
}
