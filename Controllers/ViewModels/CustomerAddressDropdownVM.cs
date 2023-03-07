using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdventureWorksSamantha.Controllers.ViewModels
{
    public class CustomerAddressDropdownVM
    {
        public List<SelectListItem> CustomerList { get; set; }
        public int CustomerId { get; set; }

        public List<SelectListItem> AddressList { get; set; }
        public int AddressId { get; set; }

        public bool? HasAddress { get; set; }

    }
}
