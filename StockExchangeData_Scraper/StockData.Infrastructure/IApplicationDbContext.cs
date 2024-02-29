using Microsoft.EntityFrameworkCore;
using StockData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure;

public interface IApplicationDbContext
{
    DbSet<Company> Companies { get; set; }
    DbSet<StockPrice> StockPrices { get; set; }
}
