using ClientDelivery.Models;
using ClientDelivery.Services;
using ClientDelivery.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            _statusOrder.ItemsSource = Enum.GetValues(typeof(Order.StatusOrderEnum));
            _containerType.ItemsSource = Enum.GetValues(typeof(Order.ContainerTypeEnum));
            orderDataGrid.ItemsSource = _orderDataList;
            _orderDataList.ListChanged += _orderDataList_ListChanged;
        }

        private void _orderDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                if(e.ListChangedType == ListChangedType.ItemChanged)
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }

            //switch (e.ListChangedType)
            //{
            //    case ListChangedType.Reset:
            //        _fileIOService.SaveData(sender);
            //        break;
            //    case ListChangedType.ItemAdded:
            //        _fileIOService.SaveData(sender);
            //        break;
            //    case ListChangedType.ItemDeleted:
            //        _fileIOService.SaveData(sender);
            //        break;
            //    case ListChangedType.ItemMoved:
            //        _fileIOService.SaveData(sender);
            //        break;
            //    case ListChangedType.ItemChanged:
            //        _fileIOService.SaveData(sender);
            //        break;
            //    case ListChangedType.PropertyDescriptorAdded:
            //        _fileIOService.SaveData(sender);
            //        break;
            //    case ListChangedType.PropertyDescriptorDeleted:
            //        _fileIOService.SaveData(sender);
            //        break;
            //    case ListChangedType.PropertyDescriptorChanged:
            //        _fileIOService.SaveData(sender);
            //        break;
            //    default:
            //        _fileIOService.SaveData(sender);
            //        break;
            //}
        }

        private void addDeliveryButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}

