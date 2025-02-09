using Newtonsoft.Json;
using StockAnalysis.Domain.Models;
using StockAnalysis.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockAnalysis.ModelingAPI.Services
{
    public class StockExchangeService : IStockExchangeService
    {
        public async Task<List<Company>> GetListedCompanies(StockExchangeType stockExchangeType)
        {
            var exchange = "";
            switch (stockExchangeType)
            {
                case StockExchangeType.HOSE:
                    exchange = "HOSE";
                    break;
                case StockExchangeType.HNX:
                    exchange = "HNX";
                    break;
                case StockExchangeType.UPCOM:
                    exchange = "UPCOM";
                    break;
                case StockExchangeType.All:
                    break;
                default:
                    break;
            }
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response;
                if (exchange!=string.Empty)
                {
                    response = await client.GetAsync($"https://wifeed.vn/api/thong-tin-co-phieu/danh-sach-ma-chung-khoan?san={exchange}");
                }
                else
                {
                    response = await client.GetAsync($"https://wifeed.vn/api/thong-tin-co-phieu/danh-sach-ma-chung-khoan");
                }
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, List<CompanyDTO>>>(jsonResponse);

                List<CompanyDTO> companyDTOs = jsonObject["data"];
                var companies = ConvertCompanyInfo(companyDTOs);
                return companies;
            }
        }
        private List<Company> ConvertCompanyInfo(List<CompanyDTO> companyDTOs)
        {
            var companies = new List<Company>();
            foreach (var companyDTO in companyDTOs)
            {
                var newCompany = new Company()
                {
                    Name = companyDTO.fullname_vi,
                    BusinessField = companyDTO.loaidn
                };
                companies.Add(newCompany);
            }
            return companies;
        }
    }
    public class CompanyDTO
    {
        public string code { get; set; }
        public string fullname_vi { get; set; }
        public string loaidn { get; set; }
        public string san { get; set; }
    }

}
