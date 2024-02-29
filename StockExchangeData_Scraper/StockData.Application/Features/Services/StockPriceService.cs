using StockData.Domain.Entities;
using StockData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Application.Features.Services;
public class StockPriceService : IStockPriceService
{
    private readonly IApplicationUnitOfWork _applicationUnitOfWork;
    private readonly IStockPriceRepository _stockPriceRepository;

    public StockPriceService(IApplicationUnitOfWork applicationUnitOfWork, 
        IStockPriceRepository stockPriceRepository)
    {
        _applicationUnitOfWork = applicationUnitOfWork;
        _stockPriceRepository = stockPriceRepository;
    }

    public void StockPriceIncluder(List<List<string>> stockPrices)
    {
        foreach (var stockPriceData in stockPrices)
        {
            var companyId = GetById(stockPriceData[0]);
            var companyStockPrice = _stockPriceRepository.CreateStockPrice(
                companyId,
                Convert.ToDouble(stockPriceData[1]),
                double.Parse(stockPriceData[2]),
                double.Parse(stockPriceData[3]),
                double.Parse(stockPriceData[4]),
                double.Parse(stockPriceData[5]),
                double.Parse(stockPriceData[6]),
                double.Parse(stockPriceData[7]),
                double.Parse(stockPriceData[8]),
                double.Parse(stockPriceData[9])
            );
            _applicationUnitOfWork.StockPrices.Add(companyStockPrice);
        }
        _applicationUnitOfWork.Save();
    }

    public int GetById(string tradeCode)
    {
        var company = _applicationUnitOfWork.Companies.Get(i => i.TradeCode.Equals(tradeCode), "").FirstOrDefault();
        return company?.Id ?? 0;
    }


}
