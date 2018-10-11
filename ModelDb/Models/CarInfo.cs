using System;
using System.Collections.Generic;

namespace ModelDb.Models
{
    public class CarInfo 
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
        public int Year { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
