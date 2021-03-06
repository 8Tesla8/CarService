﻿using System;
namespace ModelDb.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

        public string Message { get; set; }

        public int? ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
