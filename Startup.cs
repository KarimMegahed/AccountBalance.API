using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountBalance.API.Domain.Repositories;
using AccountBalance.API.Services;
using AccountBalance.API.Persistence.Contexts;
using AccountBalance.API.Persistence.Repositories;
using System.Text.Json.Serialization;

namespace AccountBalance.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("accountbalance-api-in-memory");
            });

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen();
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Account Balance V3");
            });
        }
    }
}