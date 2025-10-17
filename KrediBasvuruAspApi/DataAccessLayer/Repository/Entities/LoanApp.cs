using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Repository.Entities
{
    public class LoanApp
    {
        [Key]
        public int AppId { get; set; }
        public string BankName { get; set; }
        public string Type { get; set; }

        [Column(TypeName = "numeric(26,2)")]
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public string AppDate { get; set; }
        public string IsItApproved { get; set; }


        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }

}
