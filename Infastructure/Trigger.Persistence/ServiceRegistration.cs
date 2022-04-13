using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Application.Repositories;
using Trigger.Persistence.Contexts;
using Trigger.Persistence.Contexts.Identity;
using Trigger.Persistence.Repositories;

namespace Trigger.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TriggerDbContext>(options => options.UseSqlite("Data Source = TriggerDb;"));
            services.AddScoped<IFormatReadRepository, FormatReadRepository>();
            services.AddScoped<IFormatWriteRepository, FormatWriteRepository>();
        }
    }
}
