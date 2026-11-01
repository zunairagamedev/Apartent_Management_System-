using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.service
{
   public class ServiceModel
    {

        public int ProviderId { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ProviderName { get; set; } = "";

        public string ProviderType { get; set; } = "";
        // Electrician, Plumber, Carpenter,
        // Gas Maintainer, Sewerage Maintainer
    }

    
}
