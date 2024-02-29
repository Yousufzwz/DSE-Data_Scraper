using StockData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Domain.Repositories;

public interface IStockPriceRepository : IRepository<StockPrice, int>
{
    StockPrice CreateStockPrice(int companyId, double lastTradingPrice, double high, 
        double low, double closePrice, 
        double yesterdayClosePrice, double change, 
        double trade, double value, double volume);
}