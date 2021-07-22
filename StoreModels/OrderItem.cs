using System;

namespace StoreModels
{
    public class OrderItem
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public OrderItem()
        {}

        public override string ToString()
        {
            string output = Product.ToString() +    
                            $"Quantity: {Quantity}\n";
            return output;
        }
    }
}