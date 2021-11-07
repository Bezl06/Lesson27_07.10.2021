using System;
using System.ComponentModel.DataAnnotations;

namespace Lesson3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Food Category")]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}