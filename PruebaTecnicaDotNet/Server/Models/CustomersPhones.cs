using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaDotNet.Server.Models
{
    public class CustomersPhones
    {
        [Key]
        public int cpId { get; set; }
        public int cId { get; set; }
        [ForeignKey("cId")]
        public Customers Customers { get; set; }
        [MaxLength(20)]
        public string cpPhone { get; set; }
    }
}
