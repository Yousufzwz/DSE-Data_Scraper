﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Application.Features.Services;

public interface IStockDataCrawler
{
    public List<List<string>> StockDataCollector();
    public string GetDataInfo();
}
