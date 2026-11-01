using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.service
{
    public class ServiceRequestModel
    {
   
            public int RequestId { get; set; }
            public int CustomerId { get; set; }

            public string FlatNumber { get; set; } = "";
            public string ServiceType { get; set; } = "";
            public string ProviderType { get; set; } = "";
            public string Description { get; set; } = " ";
        public string Status { get; set; } = "Pending ";

    }
}

