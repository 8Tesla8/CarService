using System;
namespace ModelDb.Models
{
    public class SpecialOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public RepairType RepairType { get; set; }
    }
}
