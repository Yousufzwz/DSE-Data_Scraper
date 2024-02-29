using StockData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StockData.Application.Features.Services;

public class CompanyService : ICompanyService
{
    private readonly IApplicationUnitOfWork _applicationUnitOfWork;
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(IApplicationUnitOfWork applicationUnitOfWork,
        ICompanyRepository companyRepository)
    {
        _applicationUnitOfWork = applicationUnitOfWork;
        _companyRepository = companyRepository;
    }

    public void CompanyInclude(List<string> companies)
    {
        foreach (var companyId in companies)
        {
            var collectIds = _applicationUnitOfWork.Companies.Get(x => x.TradeCode == companyId, "").FirstOrDefault();
            if (collectIds == null)
            {
                var company = _companyRepository.CreateCompany(companyId);
                _applicationUnitOfWork.Companies.Add(company);
            }
        }
        _applicationUnitOfWork.Save();
    }

}
