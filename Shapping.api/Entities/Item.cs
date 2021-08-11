using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please fill out")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill out")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters")]
        [Display(Name = "تاریخ تولید")]
        public string DateManufacture { get; set; }
        [Required(ErrorMessage = "Please fill out")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters")]
        [Display(Name = "تاریخ انقضا")]
        public string DateExpiration { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }
        public Guid StoreId { get; set; }
    }
}
