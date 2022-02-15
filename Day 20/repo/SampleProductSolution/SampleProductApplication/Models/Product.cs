using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProductApplication.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Price must be between $1 and $1000")]
        public double Price { get; set; }

        [NotMapped]
        public double TotalPrice { get; set; }

        [NotMapped]
        public int BuyQty { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Quanity must be a postive number with a max of 20")]
        public int Quantity { get; set; }

        [Display(Name = "Picture")]
        public string Pic { get; set; }

        public string Description { get; set; }
    }
}
