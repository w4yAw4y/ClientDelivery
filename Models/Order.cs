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
        public class EnumBindingSourceExtension : MarkupExtension
        {
            private Type _enumType;
            public Type EnumType
            {
                get { return this._enumType; }
                set
                {
                    if (value != this._enumType)
                    {
                        if (null != value)
                        {
                            Type enumType = Nullable.GetUnderlyingType(value) ?? value;
                            if (!enumType.IsEnum)
                                throw new ArgumentException("Type must be for an Enum.");
                        }

                        this._enumType = value;
                    }
                }
            }

            public EnumBindingSourceExtension() { }

            public EnumBindingSourceExtension(Type enumType)
            {
                this.EnumType = enumType;
            }

            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                if (null == this._enumType)
                    throw new InvalidOperationException("The EnumType must be specified.");

                Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
                Array enumValues = Enum.GetValues(actualEnumType);

                if (actualEnumType == this._enumType)
                    return enumValues;

                Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
                enumValues.CopyTo(tempArray, 1);
                return tempArray;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
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
        public int Id 
        { 
            get;
            set; 
        }
        public string ClientFIO 
        { 
            get; 
            set; 
        }
        public ContainerTypeEnum ContainerType 
        { 
            get;
            set; 
        }
        public string PlaceToPickUpOrder {
            get;
            set;
        }
        public DateTime TimeToPickUpOrder { 
            get;
            set;
        }
        public string PlaceToDeliveryOrder { 
            get;
            set;
        }
        public StatusOrderEnum statusOrder { 
            get;
            set;
        }


    }
}
