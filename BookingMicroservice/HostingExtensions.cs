using BookingMicroservice.Database;
using BookingMicroservice.Repos;
using BookingMicroservice.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BookingMicroservice
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<BookingDbContext>(options =>
            {
                options.UseInMemoryDatabase("OrgStructureDatabase");
            });

            builder.Services.AddTransient<ICustomerBookingRepository, BookingRepository>();
            builder.Services.AddTransient<IEmployeeBookingRepository, BookingRepository>();
            builder.Services.AddTransient<IExternalImportRepository, ExternalRepository>();
            builder.Services.AddTransient<IExternalUpdateRepository, ExternalRepository>();

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

            return app;
        }
    }
}
