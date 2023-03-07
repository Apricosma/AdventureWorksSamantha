namespace AdventureWorksSamantha.Models
{
	public class Address
	{
		public int Id { get; set; }
		public string AddressLine1 { get; set; }
		public string? AddressLine2 { get; set; }
		public string City { get; set; }
		public string StateProvince { get; set; }
		public string CountryRegion { get; set; }

		public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

		public Address()
		{

		}

		public Address(string addressLine1, string? addressLine2, string city, string stateProvince, string countryRegion)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            StateProvince = stateProvince;
            CountryRegion = countryRegion;
        }
    }
}
