
using CMS.Logic;
using CMS.Model;
using CMS.Services;
using System;
using System.Collections.Generic;

namespace CMS.Business
{
    public class CustomerBO : ICustomerService
    {
        public Tuple<bool, string> AddCustomer(CustomerModel customermodel)
        {
            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.AddCustomer(customermodel);
            }

        }

        public Tuple<bool, string> RemoveCustomer(int id)
        {

            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.RemoveCustomer(id);
            }

        }

        public IEnumerable<CustomerModel> SearchByName(string name)
        {
            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.SearchByName(name);
            }
        }


        public IEnumerable<CustomerModel> SearchByEmail(string email)
        {
            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.SearchByEmail(email);
            }
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.GetAllCustomers();
            }
        }
        public IEnumerable<CustomerModel> GetAllActiveCustomers(bool active = true)
        {
            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.GetAllActiveCustomers(active);
            }
        }
        public CustomerModel GetCustomerByID(int id)
        {
            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.GetCustomerByID(id);
            }
        }
        public Tuple<bool, string> Edit(int id, CustomerModel customerModel)
        {
            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.Edit(id, customerModel);
            }
        }
        public Tuple<bool, string> Delete(int id)
        {
            using (var customerLogic = new CustomerLogic())
            {
                return customerLogic.Delete(id);
            }
        }

    }
}
