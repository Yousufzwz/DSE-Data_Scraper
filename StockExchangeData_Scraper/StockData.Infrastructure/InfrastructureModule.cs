using Autofac;
using StockData.Application;
using StockData.Application.Features;
using StockData.Application.Features.Services;
using StockData.Domain.Repositories;
using StockData.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure;

public class InfrastructureModule : Module
{
    private readonly string _connectionString;
    private readonly string _migrationAssembly;

    public InfrastructureModule(string connectionString, string assemblyName)
    {
        _connectionString = connectionString;
        _migrationAssembly = assemblyName;
    }
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ApplicationDbContext>().AsSelf().WithParameter("connectionString", _connectionString).WithParameter("assemblyName", _migrationAssembly).InstancePerLifetimeScope();

        builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>().WithParameter("connectionString", _connectionString).WithParameter("assemblyName", _migrationAssembly).InstancePerLifetimeScope();

        builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerLifetimeScope();

        builder.RegisterType<StockDataCrawler>().As<IStockDataCrawler>().InstancePerLifetimeScope();

        builder.RegisterType<StockPriceRepository>().As<IStockPriceRepository>().InstancePerLifetimeScope();

        builder.RegisterType<StockPriceService>().As<IStockPriceService>().InstancePerLifetimeScope();
        
        builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerLifetimeScope();

        base.Load(builder);
    }
}
