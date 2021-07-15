namespace StoreModels {
    public class LineItem
    {
        private int _id;
        private Product _product;
        private int _quantity;

        public LineItem()
        { }


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
        public int ID 
        {
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
            return Product.ToString() + 
                    $"---- Line Item Information ----\n" +
                    $"| Line Item ID: {ID}\n" + 
                    $"| Line Item Quantity: {Quantity}\n" + 
                    $"--------------------------------\n"; 
        }
    }
}