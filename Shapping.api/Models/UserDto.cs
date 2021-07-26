using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Models
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
