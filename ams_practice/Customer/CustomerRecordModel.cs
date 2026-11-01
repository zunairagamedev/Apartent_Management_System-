using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.Customer
{
   public class CustomerRecordModel
    {
   
            public int RecordId { get; set; }
            public int CustomerId { get; set; }

            public string Category { get; set; } = "";
            public string ServiceName { get; set; } = "";
            public string Description { get; set; } = "";
            public string Status { get; set; } = "Pending";
        
    }
}
