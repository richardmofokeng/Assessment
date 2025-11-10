
using CMS.Model;
using System;
using System.Collections.Generic;

namespace CMS.Services
{
    public interface ICustomerService
    {
        Tuple<bool, string> AddCustomer(CustomerModel customermodel);
        Tuple<bool, string> RemoveCustomer(int id);
        IEnumerable<CustomerModel> SearchByName(string name);
        IEnumerable<CustomerModel> SearchByEmail(string email);
        IEnumerable<CustomerModel> GetAllCustomers();
        IEnumerable<CustomerModel> GetAllActiveCustomers(bool active = true);
        CustomerModel GetCustomerByID(int id);
        Tuple<bool, string> Edit(int id, CustomerModel customerModel);
        Tuple<bool, string> Delete(int id);

    }
}
