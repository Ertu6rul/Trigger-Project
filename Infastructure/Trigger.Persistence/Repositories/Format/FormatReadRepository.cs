using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Application.Repositories;
using Trigger.Domain.Entities;
using Trigger.Persistence.Contexts;

namespace Trigger.Persistence.Repositories
{
    public class FormatReadRepository : ReadRepository<Format>, IFormatReadRepository
    {
        public FormatReadRepository(TriggerDbContext context) : base(context)
        {
            
        }
        public List<string> ReturnFileNames(IFormFileCollection files)
            {
                var nameList = new List<string>();
                foreach (var file in files)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    nameList.Add(randomName);
                }
                return nameList;
            }
    }
}
