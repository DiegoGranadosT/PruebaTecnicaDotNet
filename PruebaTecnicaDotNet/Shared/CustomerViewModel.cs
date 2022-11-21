using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaDotNet.Shared
{
    public class CustomerViewModel
    {
        public int cId { get; set; }
        public string cName1 { get; set; }
        public string cName2 { get; set; }
        public string cLastName1 { get; set; }
        public string cLastName2 { get; set; }
        public List<CustomerPhoneViewModel>? CustomerPhones { get; set; }
    }
}
