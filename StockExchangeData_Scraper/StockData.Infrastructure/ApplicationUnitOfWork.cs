using Microsoft.EntityFrameworkCore;
using StockData.Application;
using StockData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure;

public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
{
    public ICompanyRepository Companies { get; private set; }
    public IStockPriceRepository StockPrices { get; private set; }
    public ApplicationUnitOfWork(ICompanyRepository companyRepository,IStockPriceRepository stockPriceRepository, IApplicationDbContext dbContext)
        : base((DbContext)dbContext)
    {
        Companies = companyRepository;
        StockPrices = stockPriceRepository;
    }

}
