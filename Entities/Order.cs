using System;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities
{
    class Order
    {
        // #1 Propriedade(s)
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        // #2 Construtor(es)
        public Order() { }

        public Order(Client client)
        {
            Client = client;
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        // #3 Método(s)
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;

            foreach (OrderItem item in Items)
            {                
                sum += item.SubTotal(item.Quantity, item.Price); ;
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items:");

            foreach (OrderItem item in Items)
            {
                sb.Append(item.Product.Name);
                sb.Append(", $");
                sb.Append(item.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);                
                sb.Append(", Subtotal: $");
                double subtotal = item.SubTotal(item.Quantity, item.Price);
                sb.AppendLine(subtotal.ToString("F2", CultureInfo.InvariantCulture));              
            }

            sb.Append("Total price: $");
            sb.Append(this.Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
