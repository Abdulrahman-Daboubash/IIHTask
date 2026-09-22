using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public interface ICompanyService
    {
        public List<Company> GetCompanies();
        public Company GetCompany(int id);
        public void InsertCompany(Company user);
        public void UpdateCompany(int id, Company user);
        public void DeleteCompany(int id);
    }
}
