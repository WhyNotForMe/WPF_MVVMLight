using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoCrazyElephant.Service
{
    class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            System.IO.File.WriteAllLines(@"C:\Users\Fu\Desktop\Order.txt", dishes.ToArray());
            //可以存入数据库或者其他通讯服务！
        }
    }
}
