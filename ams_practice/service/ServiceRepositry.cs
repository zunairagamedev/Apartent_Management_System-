using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams_practice.service
{
    public class ServiceRepositry
    {
        private List<ServiceModel> Providers =
            new List<ServiceModel>();

        private int nextProviderId = 101;

        // Add Service Provider
        public void AddProvider(ServiceModel provider)
        {
            provider.ProviderId = nextProviderId++;
            Providers.Add(provider);
        }

        // Service Provider Login
        public ServiceModel Login(
            string username, string password)
        {
            return Providers.FirstOrDefault(
                x => x.Username == username &&
                     x.Password == password);
        }

        // Get All Service Providers
        public List<ServiceModel> GetProviders()
        {
            return Providers;
        }

        // Search Service Provider
        public ServiceModel SearchProvider(int id)
        {
            return Providers.FirstOrDefault(
                x => x.ProviderId == id);
        }

        // Delete Service Provider
        public bool DeleteProvider(int id)
        {
            ServiceModel provider = SearchProvider(id);

            if (provider == null)
            {
                return false;
            }

            Providers.Remove(provider);
            return true;
        }
    }
}