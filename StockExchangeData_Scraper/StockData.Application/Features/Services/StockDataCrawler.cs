using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StockData.Application.Features.Services;
public class StockDataCrawler : IStockDataCrawler
{
    public HtmlDocument GetStockInfo()
    {
        var html = @"https://www.dse.com.bd/latest_share_price_scroll_l.php";
        HtmlWeb web = new HtmlWeb();
        var htmlDoc = web.Load(html);
        return htmlDoc;
    }

    public List<List<string>> StockDataCollector()
    {
        var stockInfo = GetStockInfo();
        var node = stockInfo.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/section[1]/div[1]/div[3]/div[1]/div[2]/div[1]/table").ChildNodes;
        var tableRows = node.Where(n => n.NodeType == HtmlNodeType.Element);
        var stockData = new List<List<string>>();

        foreach (var item in tableRows)
        {
            var result = item.InnerText.Split('\t', '\r', '\n');

            if (!result.Contains("#"))
                stockData.Add(CleanseText(result.ToList()));
        }

        return stockData;
    }

    public List<string> CleanseText(List<string> text)
    {
        var result = new List<string>();
        foreach (var col in text)
        {
            var emptyCheck = col.Length == 0;

            if (!emptyCheck)
            {
                var separator = col.All(x => x.Equals(' '));
                if (!separator)
                {
                    if (col == "--")
                    {
                        result.Add("0");
                    }
                    else
                    {
                        result.Add(col);
                    }
                }
            }
        }
        return result;
    }

    public string GetDataInfo()
    {
        var htmlDoc = GetStockInfo();
        var status = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[1]/header[1]/div[1]/span[3]/span[1]/b[1]");
        return status.InnerText;
    }
}

