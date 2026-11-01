using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.Guest
{
    class Guest_Service
    {
       
        private Guest_Repositry repo;

        public Guest_Service(Guest_Repositry repository)
        {
            repo = repository;
        }

        public void RegisterGuest(Guest_Model guest)
        {
            repo.AddGuest(guest);
        }

        public List<Guest_Model> ViewGuests()
        {
            return repo.GetAllGuests();
        }

        public bool UpdateAvailability(int id, string status)
        {
            var guest = repo.SearchGuest(id);

            if (guest == null)
                return false;

            guest.AvailabilityStatus = status;
            return repo.UpdateGuest(guest);
        }

        public bool UpdateWaitingArea(int id, string status)
        {
            var guest = repo.SearchGuest(id);

            if (guest == null)
                return false;

            guest.WaitingAreaStatus = status;
            return repo.UpdateGuest(guest);
        }

        public bool UpdateParking(int id, string status)
        {
            var guest = repo.SearchGuest(id);

            if (guest == null)
                return false;

            guest.ParkingStatus = status;
            return repo.UpdateGuest(guest);
        }

        public bool GuestExit(int id)
        {
            var guest = repo.SearchGuest(id);

            if (guest == null)
                return false;

            guest.ExitStatus = "Exited";
            return repo.UpdateGuest(guest);
        }
    }

    
}
