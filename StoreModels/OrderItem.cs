using System;

namespace StoreModels
{
    public class OrderItem
    {
        private int _orderID;
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

        public int OrderID {
            get 
            {
                return _orderID;
            }
            set 
            {
                 _orderID = value;
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