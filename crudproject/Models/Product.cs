using System.ComponentModel.DataAnnotations;

namespace crudproject.Models
{
    public class Product
    { 
       [Key] public int Productid { get; set; }

        public string? Name { get; set; }

        public double? Price { get; set; }

      
        public virtual ICollection<Sales>? Sales { get; set; } 
    }
}

