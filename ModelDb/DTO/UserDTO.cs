using System;
using System.Collections.Generic;
using System.Text;

namespace ModelDb.DTO
{
    public class UserDTO
    {
        public bool Notify { get; set; } // for special offer

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
