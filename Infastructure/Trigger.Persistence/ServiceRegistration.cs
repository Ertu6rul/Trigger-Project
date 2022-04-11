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
            services.AddDbContext<TriggerDbContext>(options => options.UseMySQL(@"Server=localhost;Port=3306;Database=TriggerDb;Uid=root;Pwd=bb1501;"));
            services.AddScoped<IFormatReadRepository, FormatReadRepository>();
            services.AddScoped<IFormatWriteRepository, FormatWriteRepository>();
        }
    }
}
