using Cirrious.MvvmCross.Interfaces.Commands;
using CustomerManagement.Data;

namespace CustomerManagement.ViewModels
{
    public abstract class BaseEditCustomerViewModel : BaseCustomerViewModel
    {
        public abstract IMvxCommand SaveCommand { get; }

#warning Broken Code - also should probably use a service to do the save, not the static
        protected void UpdateCustomer()
        {
#if LOCAL_DATA
            XmlDataStore.UpdateCustomer(Customer);
#else
            string urlCustomers = "http://localhost/MvxDemo/customers/customer.xml";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlCustomers);
            request.Method = "PUT";
            request.ContentType = "application/xml";

            using (Stream dataStream = request.GetRequestStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Customer));
                serializer.Serialize(dataStream, customer);
            }

            request.GetResponse();
#endif
        }

#warning Broken Code - also should probably use a service to do the save, not the static
        protected void AddNewCustomer()
        {
#if LOCAL_DATA
            XmlDataStore.CreateCustomer(Customer);
#else
            string urlCustomers = "http://localhost/MvxDemo/customers/customer.xml";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlCustomers);
            request.Method = "POST";
            request.ContentType = "application/xml";

            using (Stream dataStream = request.GetRequestStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Customer));
                serializer.Serialize(dataStream, customer);
            }

            request.GetResponse();
#endif
        }
    }
}