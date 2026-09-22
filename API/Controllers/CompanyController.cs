using Application.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService) 
        {
            _companyService = companyService;
        }
        [HttpGet("GetCompanies")]
        public IActionResult GetCompanies()
        {
            var companies = _companyService.GetCompanies();
            return Ok(companies);
        }

        [HttpGet("GetCompany/{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _companyService.GetCompany(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpPost("AddCompany")]
        public IActionResult AddCompany([FromBody]Company input)
        {
            _companyService.InsertCompany(input);
            return Ok();
        }

        [HttpPut("UpdateCompany/{id}")]
        public IActionResult EditCompany(int id, [FromBody]Company input)
        {
            _companyService.UpdateCompany(id, input);
            return Ok();
        }

        [HttpDelete("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);
            return Ok();
        }
    }
}
