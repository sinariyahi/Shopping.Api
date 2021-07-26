using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Models
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DateManufacture { get; set; }
        public string DateExpiration { get; set; }
    }
}
