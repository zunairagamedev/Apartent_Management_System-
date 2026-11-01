using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.Guest
{
   public  class Guest_Model
    {
        public int GuestId { get; set; }
        public string Username { get; set; } = "";
        public string GuestName { get; set; } = "";
        public string VisitPurpose { get; set; } = "";

        public string AvailabilityStatus { get; set; } = "Pending";
        public string WaitingAreaStatus { get; set; } = "Not Checked In";
        public string ParkingStatus { get; set; } = "Not Requested";
        public string ExitStatus { get; set; } = "Not Exited";
    }

    
}
