using ClientDelivery.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDelivery.Services
{
    class FileIOService
    {
        private readonly string PATH;
        

        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<Order> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Order> { new Order() };
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Order>>(fileText);
            }

        }


        public void SaveData(object _orderDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_orderDataList);
                writer.Write(output);
            }
        }

    }
}
