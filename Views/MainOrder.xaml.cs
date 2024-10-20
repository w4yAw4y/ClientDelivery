using ClientDelivery.Models;
using ClientDelivery.Services;
using ClientDelivery.Views;
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
            _statusOrder.ItemsSource = Enum.GetValues(typeof(Order.StatusOrderEnum));
            _containerType.ItemsSource = Enum.GetValues(typeof(Order.ContainerTypeEnum));

            //_orderDataList.ListChanged += _orderDataList_ListChanged;
        }

        private void _orderDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                try { _fileIOService.SaveData(sender); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }

        private void addDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
        
    
}

