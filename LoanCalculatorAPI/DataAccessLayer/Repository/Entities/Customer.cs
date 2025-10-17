using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Repository.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public required string NameSurname { get; set; }
        public required string PhoneNum { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required DateTime RegDate { get; set; }
        public required string RegPlace { get; set; }

        public ICollection<LoanApp> LoanApps { get; set; } = new List<LoanApp>();
    }

}
