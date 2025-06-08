using System;
using System.Collections.Generic;
using System.Text;
using ExcelDataReader;
using HomeApp.Models;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

namespace HomeApp.API
{
    public static class ExcelLoaderService
    {
        public static async Task<List<Cabinet>> LoadCabinetsAsync()
        {
            var cabinets = new List<Cabinet>();
            try
            {
                var stream = await App.HttpClient.GetStreamAsync("https://view.officeapps.live.com/op/view.aspx?src=https%3A%2F%2Fprovento-electro.ru%2Fupload%2Fprice.xlsx&wdOrigin=BROWSELINK");
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var table = reader.AsDataSet().Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        cabinets.Add(new Cabinet
                        {
                            Name = row["Наименование"].ToString(),
                            Type = row["Тип"].ToString(),
                            Size = row["Габариты"].ToString(),
                            Price = decimal.Parse(row["Цена"].ToString())
                        });
                    }
                }
            }
            catch (Exception ex)
            {
             
            }
            return cabinets;
        }
    }
}
