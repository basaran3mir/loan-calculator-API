using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegDate { get; set; }
        public string RegPlace { get; set; }
    }
}
