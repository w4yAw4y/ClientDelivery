using ClientDelivery.Models;
using ClientDelivery.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ClientDelivery
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\orderDataList.json";
        private BindingList<Order> _orderDataList;
        private FileIOService _fileIOService;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainMenu_Loaded(object sender, RoutedEventArgs e) 
        {
            _fileIOService = new FileIOService(PATH);
            
            orderDataGrid.ItemsSource = _orderDataList;
            try
            {
                _orderDataList = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            _orderDataList = new BindingList<Order>()
            {
                new Order()
                {
                    Id = 0,
                    ClientFIO = "Аржанов Андрей",
                    ContainerType = Order.ContainerTypeEnum.Навалочные,
                    PlaceToPickUpOrder = "г. Москва, ул. Добролюбова, д.1, стр. 1",
                    TimeToPickUpOrder = new DateTime(2024, 10, 20, 12, 30, 00),
                    PlaceToDeliveryOrder = "г. Москва, ул. Лескова, д. 30, кв. 11 ",
                    StatusOrder = Order.StatusOrderEnum.New
                },
                new Order()
                {
                    Id = 1,
                    ClientFIO = "Аржанова Анна",
                    ContainerType = Order.ContainerTypeEnum.Опасные,
                    PlaceToPickUpOrder = "г. Москва, ул. Добролюбова, д.2, стр. 1",
                    TimeToPickUpOrder = new DateTime(2024, 10, 10, 10, 10, 00),
                    PlaceToDeliveryOrder = "г. Москва, ул. Лескова, д. 30, кв. 12 ",
                    StatusOrder = Order.StatusOrderEnum.Done
                }
            };

            _statusOrder.ItemsSource = Enum.GetValues(typeof(Order.StatusOrderEnum));
            _containerType.ItemsSource = Enum.GetValues(typeof(Order.ContainerTypeEnum));

            //_orderDataList.ListChanged += _orderDataList_ListChanged;
        }

        private void _orderDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                try {_fileIOService.SaveData(sender); }  
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }
    }
        
    
}

