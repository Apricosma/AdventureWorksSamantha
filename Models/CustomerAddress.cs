namespace AdventureWorksSamantha.Models
{
	public class CustomerAddress
	{
		public int Id { get; set; }

		public virtual Customer Customer { get; set; }
		public int CustomerId { get; set; }

		public virtual Address Address { get; set; }
		public int AddressId { get; set; }
	}
}
