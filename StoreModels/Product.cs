namespace StoreModels { 
    public class Product
    {

        private int _id;
        private string _name;
        private double _price;
        private string _description;
        private string _category;
        public Product()
        { }

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
        public string Name 
        { 
            get
            {
                return _name;
            } 
            set
            {
                _name = value;
            } 
        }
        public double Price 
        { 
            get
            {
                return _price;
            } 
            set
            {
                _price = value;
            } 
        }
        public string Description 
        { 
            get
            {
                return _description;
            } 
            set
            {
                _description = value;
            } 
        }
        public string Category 
        { 
            get
            {
                return _category;
            } 
            set
            {
                _category = value;
            } 
        }

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