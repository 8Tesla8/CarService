using System;
namespace ModelDb.Models
{
    public class RepairType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
        public int Price { get; set; }
        public double Hours { get; set; }
    }
}
