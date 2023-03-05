namespace AdventureWorksSamantha.Models
{
	public class Address
	{
		public int Id { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string StateProvince { get; set; }
		public string CountryRegion { get; set; }

		public virtual ICollection<Customer> Customers { get; set; }

		public Address()
		{

		}
	}
}
