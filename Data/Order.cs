namespace CustomerOrdersMcp.Http.Data
{
    public record Order(int Id, int CustomerId, string Product, decimal Price, decimal Total, DateTime Date);
    
    
}