using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP.src
{
    internal class OrderLine
    {
        public Product Product { get; }
        public int Quantity { get; }

        public double Total => Product.Price * Quantity;

        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
