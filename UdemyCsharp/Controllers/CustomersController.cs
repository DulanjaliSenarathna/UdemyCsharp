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
        public ActionResult Create(Customer customer)
        {
            //add customer to db
            _context.Customers.Add(customer);//only save in memory
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