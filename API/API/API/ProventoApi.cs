using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace HomeApp.API
{
    public static class ProventoApi
    {
        public static async Task<Cabinet> GetCabinet(string type, string size)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync($"https://provento-electro.ru/api/cabinets?type={type}&size={size}");
            return JsonConvert.DeserializeObject<Cabinet>(response);
        }
    }
}
