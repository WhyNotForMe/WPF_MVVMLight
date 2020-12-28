using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfDemoCrazyElephant.Service
{
    interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}
