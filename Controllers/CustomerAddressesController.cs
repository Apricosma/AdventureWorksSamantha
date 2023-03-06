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

        private bool CustomerAddressExists(int id)
        {
          return _context.CustomerAddresses.Any(e => e.Id == id);
        }
    }
}
