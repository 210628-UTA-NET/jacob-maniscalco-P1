using System;
using System.Collections.Generic;

namespace StoreModels {
    public class Order 
    {
       public int ID { get; set; }
       public int StoreFrontID { get; set; }
       public int CustomerID { get; set; }
       public List<OrderItem> Items { get; set; }
       public string Location { get; set; }
       public double Price  { get; set; }
       public DateTime TimePlaced { get; set; }

       public Order()
       { } 

       public override string ToString()
        {
            string output = $"-------------------------\n" +
                            $"|---- Customer Order ----\n" + 
                            $"-------------------------\n" +
                            $"|ID: {ID}\n" + 
                            $"|Location: {Location}\n" + 
                            $"|Price: {Price}\n" +
                            $"----------------------\n\n";
            
            foreach(OrderItem item in Items)
            {
                output += item.ToString();
            }
                            
            return output;
        }
    }
}