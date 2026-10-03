
using System.ComponentModel;
using CustomerOrdersMcp.Http.Data;
using ModelContextProtocol.Server;

namespace CustomerOrdersMcp.Http.Tools
{
    [McpServerToolType]
    public class CustomerTools(CustomerRepository repository)
    {

        [McpServerTool,
         Description("Get single customer by their unique id. Returns null if not found.")]
        public Customer? GetCustomerById(
            [Description("The unique identifier of the customer by their id")] int id)
            => repository.GetById(id);

        [McpServerTool,
         Description("Search customers by their name or email. Returns matching customers.")]
        public IEnumerable<Customer>? SearchCustomers(
            [Description("The name of the customer or their email.")] string query)
            => repository.Search(query);

        [McpServerTool,
         Description("Returns the order history for the customer by their unique id.")]
        public IEnumerable<Order>? SearchOrders(
            [Description("The customer id whom the orders belong to")] int customerId)
            => repository.GetOrdersForCustomer(customerId);
    }
}