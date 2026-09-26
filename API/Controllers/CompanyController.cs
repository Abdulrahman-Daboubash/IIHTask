using Application.Service.CompanyService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class companiesController : ControllerBase
    {
        private ICompanyService _companyService;
        public companiesController(ICompanyService companyService) 
        {
            _companyService = companyService;
        }
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _companyService.GetCompanies();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _companyService.GetCompany(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(Guid id)
        {
            _companyService.DeleteCompany(id);
            return Ok();
        }
    }
}
