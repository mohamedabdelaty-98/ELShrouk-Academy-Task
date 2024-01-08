using BusinessAccessLayer.AutoMapper;
using BusinessAccessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELShrouk_Academy_Task
{
    public static class ConfigrationServices
    {
        public static WebApplicationBuilder ConfigrationDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ShaTaskContext>(option =>
            {
                option.UseLazyLoadingProxies().
                UseSqlServer(builder.Configuration.GetConnectionString("Sql"),
                b => b.MigrationsAssembly(typeof(ShaTaskContext).Assembly.FullName));
            });
            return builder;
        }
        public static WebApplicationBuilder ConfigrationRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            return builder;
        }
        public static WebApplicationBuilder ConfigrationAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            return builder;
        }
    }
}
