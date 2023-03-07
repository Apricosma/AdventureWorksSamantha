using AdventureWorksSamantha.Controllers;
using AdventureWorksSamantha.Data;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksSamantha.Models
{
    public class Seed
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = new AWContext(serviceProvider.GetRequiredService<DbContextOptions<AWContext>>());

            Address addressOne = new Address("123 WindCrest Ave", null, "Winnipeg", "Manitoba", "Canada");
            Customer customerOne = new Customer("Jimmy", "Jimbo", "JimmyIndustries", "306-491-3183");

            Address addressTwo = new Address("492 Clarkview St", null, "Winnipeg", "Manitoba", "Canada");
            Customer customerTwo = new Customer("Cassanda", "Smith", "Empress Solutions Ltd", "934-193-3913");

            if (!context.Address.Any())
            {
                context.Address.Add(addressOne);
                context.Customer.Add(customerOne);

                context.Customer.Add(customerTwo);
                context.Address.Add(addressTwo);
            }

            await context.SaveChangesAsync();

            // make sure to get the dependant table data in before joining in a many-to-many
            CustomerAddress customerAddressOne = new CustomerAddress(customerOne.Id, addressOne.Id);
            CustomerAddress customerAddressTwo = new CustomerAddress(customerTwo.Id, addressTwo.Id);

            if (!context.CustomerAddresses.Any())
            {
                context.CustomerAddresses.Add(customerAddressOne);
                context.CustomerAddresses.Add(customerAddressTwo);
            }

            await context.SaveChangesAsync();
        }
    }
}
