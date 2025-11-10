 
using Framework.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using CMS.Entity;
using CMS.Model;
using Common;

namespace CMS.Logic
{
    public class CustomerLogic : IDisposable
    {
        private IUnitOfWork<CustomerDBEntities> _unitOfWork = null;
        public CustomerLogic()
        {
            _unitOfWork = new UnitOfWork<CustomerDBEntities>();
        }

        public Tuple<bool, string> AddCustomer(CustomerModel customermodel)
        {
            try
            {
                Customer Customer = new Customer();
                DtoTools.CopyFields(customermodel, Customer);
                _unitOfWork.CustomerRepository.Add(Customer);
                _unitOfWork.Save();
                return new Tuple<bool, string>(true, "Customer added successfully ");

            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        public Tuple<bool, string> RemoveCustomer(int id)
        {
            try
            {
                var Customer = _unitOfWork.CustomerRepository.GetById(id);
                if (Customer != null)
                {
                    Customer.Active = false;
                    _unitOfWork.Save();
                    return new Tuple<bool, string>(true, "Customer removed successfully ");
                }
                else
                {
                    return new Tuple<bool, string>(true, "Customer cannot be found");
                }
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        public IEnumerable<CustomerModel> SearchByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {

                var Customer = _unitOfWork.CustomerRepository.GetAllQueryable(x => x.Name == name).ToList();
                List<CustomerModel> customerModel = new List<CustomerModel>();
                DtoTools.CopyAll(Customer, customerModel);
                return customerModel;
            }
            else
                return new List<CustomerModel>();
        }
        public CustomerModel GetCustomerByID(int id)
        {           

                var Customer = _unitOfWork.CustomerRepository.GetById(id);
                CustomerModel customerModel = new CustomerModel();
                DtoTools.CopyFields(Customer, customerModel);
                return customerModel;
            
        }

        public IEnumerable<CustomerModel> SearchByEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {

                var Customer = _unitOfWork.CustomerRepository.GetAllQueryable(x => x.Email == email).ToList();
                List<CustomerModel> customerModel = new List<CustomerModel>();
                DtoTools.CopyAll(Customer, customerModel);
                return customerModel;
            }
            else
                return new List<CustomerModel>();
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            var customers = _unitOfWork.CustomerRepository.GetAll().ToList();
            List<CustomerModel> customerModel = new List<CustomerModel>();
            DtoTools.CopyAll(customers, customerModel);
            return customerModel;
        }
        public IEnumerable<CustomerModel> GetAllActiveCustomers(bool active)
        {
            var customers = _unitOfWork.CustomerRepository.GetAllQueryable(x => x.Active == active).ToList();
            List<CustomerModel> customerModel = new List<CustomerModel>();
            DtoTools.CopyAll(customers, customerModel);
            return customerModel;
        }
        public Tuple<bool, string> Edit(int id, CustomerModel customerModel)
        {

            var existingcustomer = _unitOfWork.CustomerRepository.GetById(id);
            if (existingcustomer != null)
            {
                DtoTools.CopyFields(customerModel, existingcustomer);
                 

                _unitOfWork.Save();
                return new Tuple<bool, string>(true, string.Empty);
            }
            else
            {
                return new Tuple<bool, string>(true, "Record could not be found");
            }

        }
        public Tuple<bool, string> Delete(int id)
        {
            var existingcustomer = _unitOfWork.CustomerRepository.GetById(id);
            if (existingcustomer != null)
            {
                try
                {
                    existingcustomer.Active = false;
                    _unitOfWork.CustomerRepository.Update(existingcustomer);                    

                    _unitOfWork.Save();
                    return new Tuple<bool, string>(true, string.Empty);
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, string>(false, ex.Message);
                }
            }
            else
            {
                return new Tuple<bool, string>(true, "Record could not be found");
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
                _unitOfWork = null;
            }
            // free native resources
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}