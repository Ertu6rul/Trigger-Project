using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigger.Domain.Entities.Models
{
    public class FormatModel
    {
        public string Name { get; set; }
        public byte[] Voice1 { get; set; }
        public byte[] Voice2 { get; set; }
        public byte[] Voice3 { get; set; }
        public byte[] Voice4 { get; set; }
        public byte[] Voice5 { get; set; }
        public byte[] Voice6 { get; set; }

    }
}
