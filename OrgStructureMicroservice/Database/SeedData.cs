using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Database
{
    public static class SeedData
    {
        public static void EnsureSeedData(WebApplication app)
        {
            using var scope = app.Services
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            OrgStructDbContext? context = scope.ServiceProvider
                .GetService<OrgStructDbContext>();

            List<Company> companies = GenerateCompanies();
            context?.Companies?.AddRange(companies);

            List<Branch> branches = new();
            List<Service> services = new();

            foreach (Company company in companies)
            {
                Branch branch = GenerateBranch(company);
                Service service = GenerateService(company);
                services.Add(service);
                branches.Add(branch);

                context?.Services?.Add(service);
                context?.Branches?.Add(branch);
            }

            List<Employee> allEmployees = new();

            foreach (Branch branch in branches)
            {
                List<Employee> employees = GenerateEmployees(branch);

                allEmployees.AddRange(employees);

                context?.Employees?.AddRange(employees);
            }

            foreach(Employee employee in allEmployees)
            {
                Random rnd = new();
                int rndService = rnd.Next(0, services.Count);
                Service service = services.ElementAt(rndService);
                employee.Services?.Add(service);
            }

            context?.SaveChanges();
        }

        public static List<Company> GenerateCompanies()
        {
            return new List<Company>
            {
                new Company
                {
                    Name = $"Test Company {Guid.NewGuid()}",
                    Type = "Test Type 1",
                    UserId = 1
                },
                new Company
                {
                    Name = $"Test Company {Guid.NewGuid()}",
                    Type = "Test Type 2",
                    UserId = 2
                }
            };
        }

        public static Branch GenerateBranch(Company company)
        {
            return new Branch
            {
                IsDeleted = false,
                CompanyId = company.Id,
                Address = $"Test Address {Guid.NewGuid()}"
            };
        }

        public static List<Employee> GenerateEmployees(Branch branch)
        {
            return new List<Employee>
            {
                new Employee
                {
                    BranchId = branch.Id,
                    FirstName = $"Employee {Guid.NewGuid()}",
                    LastName = "Test",
                    Position = "Position 1"
                },
                new Employee
                {
                    BranchId = branch.Id,
                    FirstName = $"Employee {Guid.NewGuid()}",
                    LastName = "Test",
                    Position = "Position 2"
                }
            };
        }

        public static Service GenerateService(Company company)
        {
            return new Service
            {
                Name = $"Test Service {Guid.NewGuid()}",
                Price = 100.0m,
                TimeUnits = 2,
                CompanyId = company.Id
            };
        }
    }
}
