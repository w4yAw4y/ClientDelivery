using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ClientDelivery.Models
{
    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            //PropertyChanged(this, new ProgressChangedEventArgs(propertyName));
        }
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
        public int Id { get; set; }
        public string ClientFIO { get; set; }
        public ContainerTypeEnum ContainerType { get; set; }
        public string PlaceToPickUpOrder { get; set; }
        public DateTime TimeToPickUpOrder { get; set; }
        public string PlaceToDeliveryOrder { get; set; }
        public StatusOrderEnum statusOrder { get; set; }


    }
}
