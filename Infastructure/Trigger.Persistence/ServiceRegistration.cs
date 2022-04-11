using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Application.Repositories;
using Trigger.Persistence.Contexts;
using Trigger.Persistence.Repositories;

namespace Trigger.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TriggerDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=TriggerDb;UserId=postgres;Password=bb1501;"));
            services.AddScoped<IFormatReadRepository, FormatReadRepository>();
            services.AddScoped<IFormatWriteRepository, FormatWriteRepository>();
        }
    }
}
