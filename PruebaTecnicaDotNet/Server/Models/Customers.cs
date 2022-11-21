using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaDotNet.Server.Models
{
    public class Customers
    {
        [Key]
        public int cId { get; set; }
        [MaxLength(30)]
        public string cName1 { get; set; }
        [MaxLength(30)]
        public string cName2 { get; set; }
        [MaxLength(30)]
        public string cLastName1 { get; set; }
        [MaxLength(30)]
        public string cLastName2 { get; set; }
        public List<CustomersPhones> CustomersPhones { get; set; }
    }
}
