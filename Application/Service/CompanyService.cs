using Application.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> _companyRepository;
        public CompanyService(IGenericRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void DeleteCompany(int id)
        {
            var company = _companyRepository.GetById(id);
            _companyRepository.Delete(company); 
        }

        public Company GetCompany(int id)
        {
            var company = _companyRepository.GetById(id);
            return company;
        }

        public List<Company> GetCompanies()
        {
            var companies = _companyRepository.GetAll();
            return companies;
        }

        public void InsertCompany(Company company)
        {
            var x = new Company()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                DepartmentManager = company.DepartmentManager,
                DepartmentName = company.DepartmentName
                
            };
            _companyRepository.Insert(x);
        }

        public void UpdateCompany(int id, Company company)
        {
            var x = _companyRepository.GetById(id);
            if (x != null)
            {
                x.CompanyName = company.CompanyName;
                x.DepartmentName = company.DepartmentName;
                x.DepartmentManager = company.DepartmentManager;
               
                _companyRepository.Update(x);
            }
        }


    }
}
