using Grpc.Core;

namespace Server.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private static List<CustomerModel> customers = new List<CustomerModel>()
        {
            new CustomerModel{ Id = 1, FirstName="John", LastName="Doe", Email="jdoe@gmail.com", Age=30, IsActive= true },
            new CustomerModel{ Id = 2, FirstName="Mark", LastName="Strong", Email="mstrong@gmail.com", Age=40, IsActive= true },
            new CustomerModel{ Id = 3, FirstName="Sam", LastName="Calfin", Email="scalfin@gmail.com", Age=25, IsActive= false },
        };

        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel customer = customers.FirstOrDefault(c => c.Id == request.UserId);

            if(customer == null)
            {
                customer = new CustomerModel() { Id = 0, FirstName="Unknown", LastName="Unknown" };
            }

            return Task.FromResult(customer);
        }
    }
}
