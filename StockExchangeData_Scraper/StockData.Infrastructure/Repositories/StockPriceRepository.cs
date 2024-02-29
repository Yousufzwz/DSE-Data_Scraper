using Microsoft.EntityFrameworkCore;
using StockData.Domain.Entities;
using StockData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure.Repositories;

public class StockPriceRepository : Repository<StockPrice, int>, IStockPriceRepository
{
    public StockPriceRepository(IApplicationDbContext context) : base((DbContext)context)
    {
    }

    public StockPrice CreateStockPrice(int companyId, double lastTradingPrice,
        double high, double low, double closePrice,
        double yesterdayClosePrice, double change,
        double trade, double value, double volume)
    {
        return new StockPrice
        {
            CompanyId = companyId,
            LastTradingPrice = lastTradingPrice,
            High = high,
            Low = low,
            ClosePrice = closePrice,
            YesterdayClosePrice = yesterdayClosePrice,
            Change = change,
            Trade = trade,
            Value = value,
            Volume = volume
        };
    }

}
