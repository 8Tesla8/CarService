using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDb.Models
{
    public class Car 
    {
        public int Id { get; set; }

        public CarModel CarModel { get; set; }
        public int Year { get; set; }
    }
}
