using Newtonsoft.Json;
using StockAnalysis.Domain.Models;
using StockAnalysis.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.ModelingAPI.Services
{
    public class StockInfoService : IStockInfoService
    {
        public async Task<StockInfo> GetStockInfo(string symbol)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://wifeed.vn/api/du-lieu-gia-eod/full?apikey=demo&code={symbol}&from-date=2021-01-01&to-date=2022-01-01");

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<List<StockInfoDTO>>(jsonResponse);
                var stock = ConvertStockInfo(jsonObject[0]);
                return stock;
            }
        }

        private StockInfo ConvertStockInfo(StockInfoDTO stockInfoDTO)
        {
            var stockInfo = new StockInfo();
            stockInfo.Price = Double.Parse(stockInfoDTO.close_adjust);
            stockInfo.PriceChange = Double.Parse(stockInfoDTO.changed);
            stockInfo.PriceChangeRatio = Double.Parse(stockInfoDTO.changedRatio);
            stockInfo.Volumne = Double.Parse(stockInfoDTO.volume_adjust);
            stockInfo.LastUpdate = DateTime.Parse(stockInfoDTO.lastupdate);
            return stockInfo;
        }
    }
    public class StockInfoDTO
    {
        public string mack { get; set; }
        public string close_adjust { get; set; }
        public string changed { get; set; }
        public string changedRatio { get; set; }
        public string volume_adjust { get; set; }
        public string lastupdate { get; set; }
    }
}
