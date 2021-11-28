using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StudentCRUD.Models;

namespace StudentCRUD.Helper
{
    public static class SeedData
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicesScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var _dbContext = servicesScope.ServiceProvider.GetService<StudentDBContext>();

                if (!_dbContext.Country.Any())      
                {
                    _dbContext.Country.AddRange(new List<Country> {
                new Country{
                    Name = "India"
                },
                new Country
                {
                    Name = "Sultanate of Oman"
                },
                new Country
                {
                    Name = "Pakistan"
                },
                new Country
                {
                    Name = "Sri Lanka"
                }
                }
                    );
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.ClassEntities.Any())
                {
                    _dbContext.ClassEntities.AddRange(new List<ClassEntities> {
                 new ClassEntities{
                    ClassName = "First Standard"
                },
                  new ClassEntities{
                    ClassName = "Second Standard"
                },
                   new ClassEntities{
                    ClassName = "Third Standard"
                },
                 }
                    );
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Student.Any())
                {
                    _dbContext.Student.AddRange(new List<Student> {
               new Student {
                    ClassId = 1,
                    CountryId = 1,
                    Name = "Arfaz",
                    DateOfBirth = new DateTime(2015, 12, 31)
            },
               new Student {
                    ClassId = 1,
                    CountryId = 1,
                    Name = "omar",
                    DateOfBirth = new DateTime(2015, 12, 31)
            },
               new Student {
                    ClassId = 1,
                    CountryId = 1,
                    Name = "Zain",
                    DateOfBirth = new DateTime(2015, 12, 31)
            }
               }
                    );
                    _dbContext.SaveChanges();
                }


            }

        }

    }
}
