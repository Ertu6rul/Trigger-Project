using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Persistence.Contexts;

namespace Trigger.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TriggerDbContext>
    {
        public TriggerDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TriggerDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseMySQL(@"server=localhost;port=3306;database=TriggerDb;user=root;password=bb1501;");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
