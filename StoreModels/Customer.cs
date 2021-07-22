using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StoreModels {
    public class Customer 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public List<Order> Orders { get; set; }
        public string PhoneNumber  {get; set; }

        public Customer()
        { }       

        public override string ToString()
        {
            string output = "-----------------------------\n" + 
                            $"| Name: {Name}\n" +
                            $"| ID: {ID}\n" + 
                            $"| Address: {Address}\n" +
                            $"| Phone Number: {PhoneNumber}\n" + 
                            "-----------------------------\n";
            return output;
        }
    }
}