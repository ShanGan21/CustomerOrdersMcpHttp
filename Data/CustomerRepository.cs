namespace CustomerOrdersMcp.Http.Data
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customers = new()
        {
            new Customer ( Id: 1, Name : "Anne John", Email : "JohnA@example.com",Country :"United States" ),
            new Customer ( Id: 2, Name : "Sam Micheal", Email : "MichealS@example.com",Country :"United States" ),
            new Customer ( Id: 3, Name : "George Samuel", Email : "SamuelG@example.com",Country :"United States" ),
            new Customer ( Id: 4, Name : "John Doe", Email : "DoeJ@example.com", Country : "Canada" ),
        };

        public readonly List<Order> _orders = new()
        {
            new Order(Id: 101, CustomerId: 1, Product: "Annual Cloud Plan", Price: 299.99m, Total: 299.99m, Date: DateTime.Now),
            new Order(Id: 102, CustomerId: 1, Product: "Training Workshop", Price: 1500.00m, Total: 1500.00m, Date: DateTime.Now),
            new Order(Id: 103, CustomerId: 2, Product: "Consulting Plan", Price: 2500.00m, Total: 2500.00m, Date: DateTime.Now),
            new Order(Id: 104, CustomerId: 3, Product: "Annual Book", Price: 49.99m, Total: 49.99m, Date: DateTime.Now)
        };

        public Customer? GetById(int id) =>
            _customers.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Customer> Search(string query) =>
            _customers.Where(c =>
                c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(query, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Order> GetOrdersForCustomer(int customerId) =>
            _orders.Where(o => o.CustomerId == customerId);
    }
}