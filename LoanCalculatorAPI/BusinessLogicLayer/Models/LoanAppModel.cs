using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class LoanAppModel
    {
        public int AppId { get; set; }
        public int CustomerID { get; set; }
        public string BankName { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public string AppDate { get; set; }
        public string IsItApproved { get; set; }
    }
}
