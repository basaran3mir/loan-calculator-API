using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Repository.Entities
{
    public class LoanApp
    {
        [Key]
        public int AppId { get; set; }
        public required string BankName { get; set; }
        public required string Type { get; set; }

        [Column(TypeName = "numeric(26,2)")]
        public required decimal Amount { get; set; }
        public required int Term { get; set; }
        public required string AppDate { get; set; }
        public required string IsItApproved { get; set; }


        public required int CustomerID { get; set; }
        public required Customer Customer { get; set; }
    }

}
