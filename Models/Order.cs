using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using ClientDelivery.Views;
namespace ClientDelivery.Models
{
    public class Order : INotifyPropertyChanged
    {
        public bool isReadOnly = true;


        public enum ContainerTypeEnum
        {

            Навалочные,
            Насыпные,
            Штучные,
            Наливные,
            Скоропортящиеся,
            Негабаритные,
            Опасные
        }
        public enum StatusOrderEnum
        {
            [Description("Новая")] New,
            [Description("Передано на выполнение")] TransferForExecution,
            [Description("Выполнена")] Done,
            [Description("Отменена")] Cancel
        }
        private int _id;
        private string _clientFIO;
        private ContainerTypeEnum _containerTypeEnum;
        private string _placeToPickUpOrder;
        private DateTime _timeToPickUpOrder;
        private string _placeToDeliveryOrder;
        private StatusOrderEnum _statusOrderEnum;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string ClientFIO
        {
            get { return _clientFIO; }
            set
            {
                if (_clientFIO == value)
                    return;
                _clientFIO = value;
                OnPropertyChanged("CleintFIO");
            }
        }
        public ContainerTypeEnum ContainerType
        {
            get { return _containerTypeEnum; }
            set
            {
                if (_containerTypeEnum == value)
                    return;
                _containerTypeEnum = value;
                OnPropertyChanged("ContainerType");
            }
        }
        public string PlaceToPickUpOrder
        {
            get { return _placeToPickUpOrder; }
            set
            {
                if (_placeToPickUpOrder == value)
                    return;
                _placeToPickUpOrder = value;
                OnPropertyChanged("PlaceToPickUpOrder");
            }
        }
        public DateTime TimeToPickUpOrder
        {
            get { return _timeToPickUpOrder; }
            set
            {
                if (_timeToPickUpOrder == value)
                    return;
                _timeToPickUpOrder = value;
                OnPropertyChanged("TimeToPickUpOrder");
            }
        }
        public string PlaceToDeliveryOrder
        {
            get { return _placeToDeliveryOrder; }
            set
            {
                if (_placeToDeliveryOrder == value)
                    return;
                _placeToDeliveryOrder = value;
                OnPropertyChanged("PlaceToDeliveryOrder");
            }
        }
        public StatusOrderEnum StatusOrder
        {
            get { return _statusOrderEnum; }
            set
            {
                if (_statusOrderEnum == value)
                {
                    return;
                }
                _statusOrderEnum = value;
                OnPropertyChanged("StatusOrder");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
