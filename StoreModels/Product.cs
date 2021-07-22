namespace StoreModels { 
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Product()
        { }

        public override string ToString()
        {
            string output = $"---- Product Item Information ----\n" + 
                            $"| Product Name: {Name}\n" + 
                            $"| Product ID: {ID}\n" + 
                            $"| Description: {Description}\n" +
                            $"| Category: {Category}\n" +
                            string.Format("{0:0.00}", $"| Price: {Price}\n") +
                            $"-----------------------------------\n";

            return output;
        }
    }
}