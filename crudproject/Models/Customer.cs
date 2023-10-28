using System.ComponentModel.DataAnnotations;

namespace crudproject.Models
{

    public class Customer
    {

        [Key] public int CustId { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }


        public virtual ICollection<Sales>? Sales { get; set; }
    }
}

