using System.Globalization;

namespace Course.Entities
{
    class OrderItem
    {
        // #1 Propriedade(s)
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        // #2 Construtor(es)
        public OrderItem() { }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        // #3 Método(s)
        public double SubTotal()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return Product.Name
                + ", $"
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: "
                + Quantity
                + ", Subtotal: $"
                + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}