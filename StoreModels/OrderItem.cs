using System;

namespace StoreModels
{
    public class OrderItem
    {
        private int _id;
        private Product _product;
        private int _quantity;

        public OrderItem()
        {}

        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        public int ID {
            get 
            {
                return _id;
            }
            set 
            {
                 _id = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        public override string ToString()
        {
            string output = Product.ToString() +    
                            $"Quantity: {Quantity}\n";
            return output;
        }
    }
}