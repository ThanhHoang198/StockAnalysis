using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis.Domain.Services
{
    public class HelperServices
    {
        public static string GetBusinessField(int type)
        {
            switch (type)
            {
                case 1: return "Phi tài chính";
                case 2: return "Ngân hàng";
                case 3: return "Bảo hiểm";
                case 4: return "Chứng khoán";
                default:
                    return ""; ;
            }
        }
    }
}
