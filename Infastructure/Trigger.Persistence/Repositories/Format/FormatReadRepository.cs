﻿using System;
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
    }
}
