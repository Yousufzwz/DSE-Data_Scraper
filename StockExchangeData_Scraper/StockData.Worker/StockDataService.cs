using StockData.Application.Features;
using StockData.Application.Features.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker;

public class StockDataService
{
    private readonly IStockDataCrawler _stockDataCrawler;
    private readonly ICompanyService _companyService;
    private readonly IStockPriceService _stockPriceService;

    public StockDataService(IStockDataCrawler stockDataCrawler, IStockPriceService stockPriceService,
        ICompanyService companyService)
    {
        _stockDataCrawler = stockDataCrawler;
        _companyService = companyService;
        _stockPriceService = stockPriceService;
    }

    public string GetStockExchangeStatus() => _stockDataCrawler.GetDataInfo();

    public void GetStockExchangeData()
    {
        var stockData = _stockDataCrawler.StockDataCollector();
        var companies = new List<string>();
        var stockPrices = new List<List<string>>();

        foreach (var item in stockData)
        {
            var stock = new List<string>();
            companies.Add(item[1]);
            for (int i = 1; i < item.Count(); i++)
            {
                stock.Add(item[i]);
            }
            stockPrices.Add(stock);
        }

        CompanyIncluder(companies);
        StockPriceIncluder(stockPrices);
    }

    public void CompanyIncluder(List<string> companies) => _companyService.CompanyInclude(companies);

    public void StockPriceIncluder(List<List<string>> stockPrices) => _stockPriceService.StockPriceIncluder(stockPrices);
}
