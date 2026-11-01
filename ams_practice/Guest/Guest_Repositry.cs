using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.Guest
{
    public class Guest_Repositry
    {
        

       
            // Store guest records temporarily
            private List<Guest_Model> Guests =
                new List<Guest_Model>();

            // 1. Add Guest
            public void AddGuest(Guest_Model guest)
            {
                guest.GuestId = Guests.Count + 1;
                Guests.Add(guest);

                Console.WriteLine("Guest added successfully!");
            }

            // 2. View All Guests
            public List<Guest_Model> GetAllGuests()
            {
                return Guests;
            }

            // 3. Search Guest
            public Guest_Model SearchGuest(int id)
            {
                return Guests.FirstOrDefault(
                    x => x.GuestId == id);
            }

            // 4. Update Guest
            public bool UpdateGuest(Guest_Model guest)
            {
                Guest_Model oldGuest = SearchGuest(guest.GuestId);

                if (oldGuest == null)
                {
                    return false;
                }

                oldGuest.Username = guest.Username;
                oldGuest.GuestName = guest.GuestName;
                oldGuest.VisitPurpose = guest.VisitPurpose;
                oldGuest.AvailabilityStatus = guest.AvailabilityStatus;
                oldGuest.WaitingAreaStatus = guest.WaitingAreaStatus;
                oldGuest.ParkingStatus = guest.ParkingStatus;
                oldGuest.ExitStatus = guest.ExitStatus;

                return true;
            }

            // 5. Delete Guest
            public bool DeleteGuest(int id)
            {
                Guest_Model guest = SearchGuest(id);

                if (guest == null)
                {
                    return false;
                }

                Guests.Remove(guest);
                return true;
            }
    }
}

