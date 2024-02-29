using Autofac;

namespace StockData.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly StockDataService _stockDataService;

    public Worker(ILogger<Worker> logger, StockDataService stockDataService)
    {
        _logger = logger;
        _stockDataService = stockDataService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            if (_stockDataService.GetStockExchangeStatus().ToLower() == "open")
            {
                _stockDataService.GetStockExchangeData();
            }
            else
            {
                _logger.LogInformation("Stock Market Closed at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(60000, stoppingToken);
        }
    }
}