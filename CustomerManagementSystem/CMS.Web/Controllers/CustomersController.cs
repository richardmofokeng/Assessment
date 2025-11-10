using CMS.Model;
using CMS.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagement.Controllers
{
    public class CustomersController : Controller
    {
        [Inject]
        private readonly ICustomerService icustomerService;
        public CustomersController(ICustomerService _icustomerService)
        {
            icustomerService = _icustomerService;
        }
        public CustomersController()
        {
            
        }

        public ActionResult Index(string searchName = null, string searchEmail = null)
        {
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                var results = icustomerService.SearchByName(searchName);
                ViewData["SearchName"] = searchName;
                return View(results);
            }

            if (!string.IsNullOrWhiteSpace(searchEmail))
            {
                var results = icustomerService.SearchByEmail(searchEmail);
                ViewData["SearchEmail"] = searchEmail;
                return View(results);
            }

            var all = icustomerService.GetAllActiveCustomers(true);
            return View(all);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var Customer = (icustomerService.GetAllCustomers()).FirstOrDefault(b => b.CustomerID == id);
            if (Customer == null)
                return View();
            return View(Customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customermodel)
        {
            try
            {
                if (!ModelState.IsValid) return View(customermodel);

                icustomerService.AddCustomer(customermodel);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var Customer = icustomerService.GetCustomerByID(id);
            if (Customer == null)
                return View();
            return View(Customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerModel customermodel)
        {
            try
            {
                if (!ModelState.IsValid) return View(customermodel);

                var results = icustomerService.Edit(id, customermodel);
                if (results.Item1)
                    return RedirectToAction(nameof(Index));
                else
                    return View(customermodel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var Customer = icustomerService.GetCustomerByID(id);
            if (Customer == null)
                return HttpNotFound();

            return View(Customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerModel customermodel)
        {
            try
            {
                // TODO: Add delete logic here
                var Customer = icustomerService.GetCustomerByID(id);
                if (Customer != null)
                {
                    var results = icustomerService.Delete(id);
                    if (results.Item1)
                        return RedirectToAction("Index");
                    else
                        return View(customermodel);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
