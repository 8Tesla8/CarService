using System;
using System.Collections.Generic;
using System.Text;

namespace ModelDb.DTO
{
    public class AppointmentDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public UserDTO User { get; set; }
        public CarDTO Car { get; set; }

        public string ServiceType { get; set; }

        public string Message { get; set; } 
    }
}
