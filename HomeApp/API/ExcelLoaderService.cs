using System;
using System.Collections.Generic;
using System.Text;
using ExcelDataReader;
using HomeApp.Models;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp.API
{
    public static class ExcelLoaderService
    {
        public static async Task<List<Cabinet>> LoadCabinetsAsync()
        {
            var cabinets = new List<Cabinet>();

            try
            {
                // 1. Загрузка файла
                var stream = await App.HttpClient.GetStreamAsync(
                    "https://provento-electro.ru/upload/price.xlsx");

                // 2. Настройка читателя
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    // 3. Парсинг данных (адаптируйте под вашу структуру Excel)
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        cabinets.Add(new Cabinet()
                        {
                            Name = row["Наименование"].ToString(),
                            Type = row["Тип"].ToString(),
                            Size = row["Габариты"].ToString(),
                            Price = decimal.Parse(row["Цена"].ToString()),
                            Url = row["Ссылка"]?.ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return cabinets;
        }
    }
}
