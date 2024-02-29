using StockData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Application.Features.Services;

public interface ICompanyService
{
    void CompanyInclude(List<string> company);
}
