using Microsoft.EntityFrameworkCore;
using StockData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly string _connectionString;
    private readonly string _assemblyName;

    public ApplicationDbContext(string connectionString, string assemblyName)
    {
        _connectionString = connectionString;
        _assemblyName = assemblyName;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString,
                x => x.MigrationsAssembly(_assemblyName));

        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Company>()
            .HasMany(x => x.StockPrices)
            .WithOne(y => y.Company)
            .HasForeignKey(z => z.CompanyId);

        base.OnModelCreating(builder);
    }


    public DbSet<Company> Companies { get; set; }
    public DbSet<StockPrice> StockPrices { get; set; }
}


