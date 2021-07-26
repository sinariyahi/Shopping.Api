using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Models
{
    public class StoreForUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
