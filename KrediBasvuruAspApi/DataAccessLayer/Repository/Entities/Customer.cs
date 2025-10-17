using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Repository.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegDate { get; set; }
        public string RegPlace { get; set; }

        public ICollection<LoanApp> LoanApps { get; set; }
    }

}
