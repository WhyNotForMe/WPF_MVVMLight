using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoHenJigg.Model;

namespace WpfDemoHenJigg.Service
{
    interface IStudentsService
    {
        List<Student> LoadAllStudents();
    }
}
