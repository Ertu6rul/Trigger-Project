using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Domain.Entities.Common;

namespace Trigger.Domain.Entities
{
    public class Format: BaseEntity
    {
        public string Voice1Url { get; set; }
        public string Voice2Url { get; set; }
        public string Voice3Url { get; set; }
        public string Voice4Url { get; set; }
        public string Voice5Url { get; set; }
        public string Voice6Url { get; set; }
        public int Score { get; set; }
    }
}
