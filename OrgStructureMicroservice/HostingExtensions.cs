using Microsoft.EntityFrameworkCore;
using OrgStructureMicroservice.Database;
using OrgStructureMicroservice.Repos;
using OrgStructureMicroservice.Repos.Interfaces;
using Serilog;

namespace OrgStructureMicroservice
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<OrgStructDbContext>(options =>
            {
                options.UseInMemoryDatabase("OrgStructureDatabase");
            });

            builder.Services.AddTransient<ICompaniesRepository, CompaniesRepository>();
            builder.Services.AddTransient<IBranchesRepository, BranchesRepository>();
            builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            builder.Services.AddTransient<IServicesRepository, ServicesRepository>();

            builder.Services.AddOptions<GlobalOptions>()
                .Bind(builder.Configuration.GetSection(GlobalOptions.Name));

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            SeedData.EnsureSeedData(app);

            return app;
        }
    }
}