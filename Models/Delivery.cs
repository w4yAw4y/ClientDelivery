using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDelivery.Models
{
    public class Order
    {
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
            Новая,
            ПереданоНаВыполнение,
            Выполнена,
            Отменена
        }
        public int Id { get; set; }
        public string ClientFIO { get; set; }
        public ContainerTypeEnum ContainerType { get; set; }
        public string PlaceToPickUpOrder { get; set; }
        public DateTime TimeToPickUpOrder { get; set; }
        public string PlaceToDeliveryOrder {  get; set; }
        public StatusOrderEnum statusOrder { get; set; }

    }
}
