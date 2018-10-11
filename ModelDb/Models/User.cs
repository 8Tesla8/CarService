using System;
using System.Collections.Generic;

namespace ModelDb.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool Notify { get; set; } // for special offer

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public ICollection<CarInfo> Cars { get; set; }
    }
}
