using System.ComponentModel.DataAnnotations;

namespace crudproject.Models
{
    public class Store
    {
        [Key]public int Storeid { get; set; }

        public string? Storename { get; set; }

        public string? Address { get; set; }
        public virtual ICollection<Sales>? Sales { get; set; }


    }
}
