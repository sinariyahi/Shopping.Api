using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Entities
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please fill out")]
        [MinLength(100,ErrorMessage = "Maximum 100 characters")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill out")]
        [MaxLength(100,ErrorMessage = "Maximum 100 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please fill out")]
        [MaxLength(1500,ErrorMessage = "Maximum 1500 characters")]
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        public ICollection<Item> Items { get; set; } = new List <Item>();
    }
}
