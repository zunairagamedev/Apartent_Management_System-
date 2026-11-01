using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ams_practice.Customer
{
    public class customer_record_repository
    {
        // Temporary storage for customer records
        private List<CustomerRecordModel> Records =  new List<CustomerRecordModel>();

        private int nextRecordId = 1;

        // Add Customer Record
        public void AddRecord(CustomerRecordModel record)
        {
            record.RecordId = nextRecordId++;
            Records.Add(record);
        }

        // Get All Customer Records
        public List<CustomerRecordModel> GetAllRecords()
        {
            return Records;
        }

        // Get Records of a Specific Customer
        public List<CustomerRecordModel> GetCustomerRecords(
        int customerId)
        {
            return Records.Where(
                x => x.CustomerId == customerId
            ).ToList();
        }

        // Search Customer Record
        public CustomerRecordModel SearchRecord(int recordId)
        {
            return Records.FirstOrDefault(
                x => x.RecordId == recordId
            );
        }

        // Update Record Status
        public bool UpdateRecordStatus(int recordId, string status)
        {
            CustomerRecordModel record = SearchRecord(recordId);

            if (record == null)
            {
                return false;
            }

            record.Status = status;
            return true;
        }
    }
}
