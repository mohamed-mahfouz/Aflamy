using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; //For Using Extention Method (Include) 
using Aflame.ViewModels;
using Aflame.Models;

namespace Aflame.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context; //We Defined it to can access DB, So we made it Private

                                         
        public CustomersController() //We need to initialize it by using Constructor, Why we initlizae it and why Constructor? 
                                    // => i think when we request any related data of customer this class(CustomerController) will be called to perform specific request.
                                    // used Constrcutor he initilize what insiede it when class called.

        {
            _context = new ApplicationDbContext();  // but it's now Disposable(we can use it once) 
                                                   
        }
       
        protected override void Dispose(bool disposing)
        {                         //  why we dispose it? => i think if we don't dispose it, we can't use it except once time
            _context.Dispose();  // To Dispose it, so We can use it Continuously
        }
        public ActionResult Index()
        {
            // we use Include to load in Customer and MembershipType Together.
            // To solve NullReferenceExceptionError, so it's happen cuz you 
            // define customer object only not related object(MembershipType)

             // Customer is Dbset which defiend in DbContext
                                                                                         // This statement can't execute without to add Method ToList()
                                                                                         // to execute immediately 
            return View();
        }
        public ActionResult New() // at Video(Save New Form), why we don't use var cutomers = _context.Customers.ToList();? => i think cuz we access Property not Value of Property
                                  // why use Dbset<Membershiptype>? However,when we Get Name Of Membershiptype later we don't use Dbset?
        {
            var membershiptypes = _context.MembershipTypes.ToList(); // why?? we can't send membershiptype in View cuz it's not work later when we edit customer??? => i think cuz if we send it to view you need to use Directive 
                                                                     // model for membershiptype and within this case we can't edit customer cuz it's not available Directive of customer
                                                                     // so we need to pass aslo customer object to view,
                                                                     // in this situation we need to make seprate viewModel enclose it Customer object & MembershipType and passed together for view    
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershiptypes,
                Customer = new Customer() // why we added it??
            };

            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) // why we use this parameter instead of CusotmerViewModel???
                                                   // i think => when we u make debug u see MemershipType is null 
                                                   // so he can't send null data to server..
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),

                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id != 0)
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id); // i use here Single cuz i'm sure it's already in DB So not need for handle exception.
                customerInDb.Name = customer.Name; // This the best way for update customer cuz may be malicious user modify
                customerInDb.BD = customer.BD;    // or enter any thing and TryUpdateModel() executed it at all.
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            else
            {
                _context.Customers.Add(customer); // Just it added at Memory
            }
            _context.SaveChanges(); // Now it added to Database..
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Details(int id)
        {                                                                       // we called SingleOrDefault as ExtentionMethod
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); //SingleorDefault return null 
                                                                               // single only return excpetion only

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var cusotmer = _context.Customers.SingleOrDefault(c => c.Id == id); // We get id of customer

            if (cusotmer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = cusotmer // we assign customer
            };
            return View("CustomerForm", viewModel); // we send it to view, so you can edit it, and prevent NullReferenceExceptionError...
        }
    }
}