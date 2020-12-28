using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;    //GalaSoft.MvvmLight.Command导致RelayCommand中CanExecute不能自动更新！
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml;
using WpfDemoCrazyElephant.Model;
using WpfDemoCrazyElephant.Service;
using WpfDemoCrazyElephant.ViewModel;

namespace WpfDemoCrazyElephant.ViewModel
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



        private RelayCommand selectItemCommand;

        public RelayCommand SelectItemCommand
        {
            set { selectItemCommand = value; }
            get
            {
                if (selectItemCommand == null)
                {
                    //return new RelayCommand(new Action(SelectItemCmdExe), new Func<bool>(SelectItemCmdCanExe));
                    return new RelayCommand(() => SelectItemCmdExe(), SelectItemCmdCanExe);
                }

                return selectItemCommand;

            }
        }


        private RelayCommand placeOrderCommand;

        public RelayCommand PlaceOrderCommand
        {
            set { placeOrderCommand = value; }
            get
            {
                if (placeOrderCommand != null)
                {
                    return placeOrderCommand;
                }

                //return new RelayCommand(new Action(PlaceOrderCmdExe), new Func<bool>(PlaceOrderCmdCanExe));
                return new RelayCommand(() => PlaceOrderCmdExe(), PlaceOrderCmdCanExe);
            }
        }



        #region Count属性
        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                if (count == value) { return; }
                count = value;
                this.RaisePropertyChanged("Count");
            }
        }

        #endregion

        #region Restaurant属性
        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                if (restaurant == value) { return; }
                restaurant = value;
                this.RaisePropertyChanged("Restaurant");
            }
        }
        #endregion

        #region DishItem属性
        private List<DishItemViewModel> dishItem;

        public List<DishItemViewModel> DishItems
        {
            get { return dishItem; }
            set
            {
                if (dishItem == value) { return; }
                dishItem = value;
                this.RaisePropertyChanged("DishItems");
            }
        }

        #endregion


        public MainViewModel()
        {
            this.LoadRestaurant();
            this.LoadDishMenu();
        }

        private bool SelectItemCmdCanExe()
        {
            if (DishItems.Count > 0)
            {
                return true;
            }
            return false;
        }

        private bool PlaceOrderCmdCanExe()
        {   
            if (this.Count > 0)
            {
                return true;
            }

            return false;
        }

        private void SelectItemCmdExe()
        {
            this.Count = this.DishItems.Count(i => i.IsSelected == true);
        }

        private void PlaceOrderCmdExe()
        {
            var selectedDishes = this.DishItems.Where(i => i.IsSelected == true).Select(i => i.Dish.Name+","+i.Dish.Category).ToList();

            IOrderService orderService = new MockOrderService();    //使用IOrderService接口而不是MockOrderService类来声明变量！！！
            orderService.PlaceOrder(selectedDishes);        //得到LINQ查询的List结果！
            MessageBox.Show("订餐成功！", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);

        }


        private void LoadDishMenu()
        {

            IDataService xds = new XmlDataService();    //使用IDataService接口而不是XmlDataService类声明变量！！！
            var dishes = xds.GetAllDishes();            //获取Model中Dish源数据，此方法体内算法可以更换！

            this.DishItems = new List<DishItemViewModel>();

            foreach (var dish in dishes)
            {   //遍历Model中Dish源数据，传送至ViewModel中DishItem供显示，可用lambda表达式替换！
                DishItemViewModel item = new DishItemViewModel();
                item.Dish = dish;
                this.DishItems.Add(item);
            }

        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant()
            { Name = "CrazyElephant", Address = "北京市海淀区紫金庄园1号楼1层113", Telephone = "010-82650336" };         //实例化后赋值！

        }
    }
}

