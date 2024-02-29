using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Application.Features;

public interface IStockPriceService
{
    int GetById(string tradeCode);
    void StockPriceIncluder(List<List<string>> stockPrice);
}
