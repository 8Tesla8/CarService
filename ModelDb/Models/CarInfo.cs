using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDb.Models
{
    public class CarInfo 
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
        public int Year { get; set; }

        [NotMapped]
        public ICollection<User> User { get; set; }
    }
}
