namespace StoreModels {
    public class LineItem
    {
        public int ID { get; set; }
        public int StoreID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public LineItem()
        { }


       

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