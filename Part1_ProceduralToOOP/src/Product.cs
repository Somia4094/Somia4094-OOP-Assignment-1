using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP.src
{
    internal class Product
    {
        

    
        public int Id { get; }
        public string Name { get; }
        public double Price { get; }
        public int Stock { get; private set; }

        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public bool ReduceStock(int quantity)
        {
            if (quantity <= 0 || Stock < quantity)
                return false;

            Stock -= quantity;
            return true;
        }

        public override string ToString()
        {
            return $"#{Id}  {Name}  price={Price:F2}  stock={Stock}";
        }
    
}
}
