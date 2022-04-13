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
        public IFormFile Voice1 { get; set; }
        public IFormFile Voice2 { get; set; }
        public IFormFile Voice3 { get; set; }
        public IFormFile Voice4 { get; set; }
        public IFormFile Voice5 { get; set; }
        public IFormFile Voice6 { get; set; }

    }
}
