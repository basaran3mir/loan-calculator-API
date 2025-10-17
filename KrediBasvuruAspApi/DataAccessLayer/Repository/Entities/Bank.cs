using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Repository.Entities
{
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BankId { get; set; }
        public string BankName { get; set; }
    }
}
