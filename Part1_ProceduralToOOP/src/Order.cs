using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP.src
{
    internal class Order
    {

        private const int MaxLinesPerOrder = 20;

        private readonly List<OrderLine> lines = new();

        public int Id { get; }
        public Customer Customer { get; }
        public string Date { get; }
        public bool IsPaid { get; private set; }

        public IReadOnlyList<OrderLine> Lines => lines;

        public Order(int id, Customer customer, string date)
        {
            Id = id;
            Customer = customer;
            Date = date;
            IsPaid = false;
        }

        public bool AddLine(Product product, int quantity)
        {
            if (IsPaid)
                return false;

            if (lines.Count >= MaxLinesPerOrder)
                return false;

            if (quantity <= 0)
                return false;

            if (!product.ReduceStock(quantity))
                return false;

            lines.Add(new OrderLine(product, quantity));
            return true;
        }

        public bool MarkAsPaid()
        {
            if (lines.Count == 0)
                return false;

            IsPaid = true;
            return true;
        }

        public double CalculateTotal()
        {
            double total = 0;

            foreach (OrderLine line in lines)
            {
                total += line.Total;
            }

            if (Customer.IsVip)
                total *= 0.90;

            return total;
        }
    }
}
