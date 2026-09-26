using Application.Repository;

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> _companyRepository;
        public CompanyService(IGenericRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void DeleteCompany(Guid id)
        {
            var company = _companyRepository.GetById(id);
            _companyRepository.Delete(company); 
        }

        public Company GetCompany(Guid id)
        {
            var company = _companyRepository.GetById(id);
            return company;
        }

        public IQueryable<Company> GetCompanies()
        {
            var companies = _companyRepository.GetAll();
            return companies;
        }

        


    }
}
