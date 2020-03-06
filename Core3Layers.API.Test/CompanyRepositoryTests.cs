using Core3Layers.Infrastructure;
using Core3Layers.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Core3Layers.API.Test
{
    public class CompanyRepositoryTests
    {
        private readonly ITestOutputHelper _output;

        public CompanyRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public async void GetCompanies_PageSizeIsThree_ReturnsOneCompany()
        {
            // Arrange

            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;


            using (var context = new ApplicationDbContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var customer = new Core.Entities.Customer()
                {
                    Id = new Guid(),
                    Name = "Jorge",
                    Email = "jorger@gmail.com",
                    Stage = true,
                    Type = 1
                };

                context.Customer.Add(customer);

                context.Company.Add(new Core.Entities.Company()
                { CustomerId = customer.Id, Name = "Empresa do Jorger", Cnpj = "99999999999999" });

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var companyRepository = new CompanyRepository(context);

                // Act
                var companies = await companyRepository.GetCompanies(1, 3);

                // Assert
                Assert.Equal(1, companies.Count);
            }
        }
    }
}
