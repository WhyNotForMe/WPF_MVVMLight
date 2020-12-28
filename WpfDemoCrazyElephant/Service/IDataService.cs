using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoCrazyElephant.Model;

namespace WpfDemoCrazyElephant.Service
{
    interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
