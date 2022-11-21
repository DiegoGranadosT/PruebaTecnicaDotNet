using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaDotNet.Shared
{
    public class CustomerPhoneViewModel
    {
        public int cpId { get; set; }
        public int cId { get; set; }
        public string cpPhone { get; set; }
    }
}
