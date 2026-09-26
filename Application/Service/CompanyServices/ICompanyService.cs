
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.CompanyService
{
    public interface ICompanyService
    {
        public IQueryable<Company> GetCompanies();
        public Company GetCompany(Guid id);
        public void DeleteCompany(Guid id);
    }
}
