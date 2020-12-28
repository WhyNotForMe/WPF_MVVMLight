using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;    //GalaSoft.MvvmLight.Command����RelayCommand��CanExecute�����Զ����£�
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



        #region Count����
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

        #region Restaurant����
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

        #region DishItem����
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

            IOrderService orderService = new MockOrderService();    //ʹ��IOrderService�ӿڶ�����MockOrderService������������������
            orderService.PlaceOrder(selectedDishes);        //�õ�LINQ��ѯ��List�����
            MessageBox.Show("���ͳɹ���", "��ܰ��ʾ", MessageBoxButton.OK, MessageBoxImage.Warning);

        }


        private void LoadDishMenu()
        {

            IDataService xds = new XmlDataService();    //ʹ��IDataService�ӿڶ�����XmlDataService����������������
            var dishes = xds.GetAllDishes();            //��ȡModel��DishԴ���ݣ��˷��������㷨���Ը�����

            this.DishItems = new List<DishItemViewModel>();

            foreach (var dish in dishes)
            {   //����Model��DishԴ���ݣ�������ViewModel��DishItem����ʾ������lambda���ʽ�滻��
                DishItemViewModel item = new DishItemViewModel();
                item.Dish = dish;
                this.DishItems.Add(item);
            }

        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant()
            { Name = "CrazyElephant", Address = "�����к������Ͻ�ׯ԰1��¥1��113", Telephone = "010-82650336" };         //ʵ������ֵ��

        }
    }
}

