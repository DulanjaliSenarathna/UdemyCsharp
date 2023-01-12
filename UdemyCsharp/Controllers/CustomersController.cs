using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyCsharp.Models;
using UdemyCsharp.ViewModels;

namespace VidlyCSharp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            //get membership types from db
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
           
            return View("CustomerForm",viewModel);
           
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            //if customer have not an id, add customer to db
            if (customer.Id == 0)
                _context.Customers.Add(customer);//only save in memory
            //if customer already have an id, then update customer details
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //instead of TryUpdate(customerInDb) method (do not use this, because this provides security holes in app. this method defaultly update all the fields is form. but we can use 3rd argument , that is string array that contains fields that we should update. But it is hard to refactor this field names future. we should rename them one by one)

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter= customer.IsSubscribedToNewsLetter;

                //intead of above 4 lines, we can use tool called AutoMapper to mapping object properties. 
                //Mapper.Map(customer, customerInDb)
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");//redirect to list of customer
        }

        // GET: Customer
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }


        public ActionResult Edit(int id)
        {
            //get customer from db by id
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            //override mvc convention - we specify the view that we want to render in side the View(). otherwise by default this action return Edit view.
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}