using Domain.Entities;
using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Data
{
    public static class UserSeedData
    {
        public static void UserSeed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!context.Companies.Any())
            {
                var companies = new List<Company>
                {
                    new Company {CompanyName = SystemCompany.IIH.ToString(), Code = SystemCompany.IIH ,DepartmentName = "IT" , DepartmentManager = "Wael"},
                    new Company {CompanyName = SystemCompany.Amazon.ToString(), Code = SystemCompany.Amazon , DepartmentName = "Shopping" , DepartmentManager = "Ali"},
                    new Company {CompanyName = SystemCompany.Tetra.ToString(), Code = SystemCompany.Tetra , DepartmentName = "Engineer" , DepartmentManager = "Ahman"}
                };
                context.Companies.AddRange(companies);
                context.SaveChanges();
            }


        }
    }
}
