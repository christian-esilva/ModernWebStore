namespace ModernWebStore.Domain.Commands.OrderCommands
{
    public class CreateOrderItemCommand
    {
        public CreateOrderItemCommand(int quantity, decimal price, int product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Product { get; set; }
    }
}
