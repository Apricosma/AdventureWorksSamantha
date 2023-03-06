using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureWorksSamantha.Data;
using AdventureWorksSamantha.Models;
using AdventureWorksSamantha.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AdventureWorksSamantha.Controllers
{
    public class CustomerAddressesController : Controller
    {
        private readonly AWContext _context;

        public CustomerAddressesController(AWContext context)
        {
            _context = context;
        }

        // GET: CustomerAddresses
        public async Task<IActionResult> Index()
        {
            //var aWContext = _context.CustomerAddresses.Include(c => c.Address).Include(c => c.Customer);
            //return View(await aWContext.ToListAsync());

            var viewModel = new CustomerAddressDropdownVM();
            viewModel.CustomerList = _context.Customer.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName
            }).ToList();

            viewModel.AddressList = _context.Address.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AddressLine1
            }).ToList();

            return View(viewModel);
        }

        // plug in the view model and get the ids to compare
        [HttpPost]
        public IActionResult Index(CustomerAddressDropdownVM viewModel)
        {
            // checks if the CustomerAddress database context 
            // matches the current view model
            bool? hasAddress = _context.CustomerAddresses.Any(ca => 
                ca.CustomerId == viewModel.CustomerId &&
                ca.AddressId == viewModel.AddressId
            );

            viewModel.HasAddress = hasAddress;

            // re-plugging in the list to the view model seems to be the only way I can resolve
            // an exception from happening. There has to be an easier way to recycle the old objects but I'm unsure.
            viewModel.CustomerList = _context.Customer.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName
            }).ToList();

            viewModel.AddressList = _context.Address.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AddressLine1
            }).ToList();

            return View(viewModel);
        }

        private bool CustomerAddressExists(int id)
        {
          return _context.CustomerAddresses.Any(e => e.Id == id);
        }
    }
}
