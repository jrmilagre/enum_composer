namespace Course.Entities
{
    class OrderItem
    {
        // #1 Propriedade(s)
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public double Total { get; private set; }

        // #2 Construtor(es)
        public OrderItem() { }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        // #3 Método(s)
        public double SubTotal(int quantity, double price)
        {
            return quantity * price;

        }
    }
}