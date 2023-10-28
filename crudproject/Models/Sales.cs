using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;
using System.Text.Json.Serialization;

namespace crudproject.Models
{
    public class Sales
    {
        //
        //public int Salesid { get; set; }
        [Key]
        public int Salesid { get; set; }

       [ForeignKey("Product")] public int? Productid { get; set; }

        [ForeignKey("Customer")] public int? Custid { get; set; }

        [ForeignKey("Store")] public int? Storeid { get; set; }

        public DateTime? Datesold { get; set; }

        public virtual Customer? Cust { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }


    }
}
