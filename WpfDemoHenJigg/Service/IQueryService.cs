using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoHenJigg.ViewModel;

namespace WpfDemoHenJigg.Service
{
    interface IQueryService
    {
        List<StudentItemViewModel> QueryStudentItem(ObservableCollection<StudentItemViewModel> stuList,string search);
    }
}
