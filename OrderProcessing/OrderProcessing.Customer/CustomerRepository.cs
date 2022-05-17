namespace OrderProcessing.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new List<Customer>();

        public CustomerRepository()
        {
            customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "duha@yahoo.com"
            });
            customers.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = "Jane",
                LastName = "Doe",
                EmailAddress = "jane@hotmail.com"
            });
        }

        public Task<List<Customer>> GetAllCustomer()
        {
            return Task.FromResult(customers);
        }
    }
}