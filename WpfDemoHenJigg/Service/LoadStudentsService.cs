using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoHenJigg.Model;

namespace WpfDemoHenJigg.Service
{
    public class LoadStudentsService : IStudentsService
    {
        public List<Student> LoadAllStudents()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 30; i++)
            {
                students.Add(new Student()
                {
                    Id = 2020 + i,
                    Name = $"Sample{i}",
                    Age = 20,
                    Sex = "Male"
                });
            }

            return students;
        }
    }
}
