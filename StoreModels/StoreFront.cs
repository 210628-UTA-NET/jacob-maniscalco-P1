using System;
using System.Collections.Generic;

namespace StoreModels {
    public class StoreFront 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<LineItem> Inventory { get; set; }
        public List<Order> Orders { get; set; }
        public StoreFront()
        { }

        public override string ToString()
        {
            string output = $"|--------------------\n" + 
                            $"|Name: {Name}\n" + 
                            $"|Store ID: {ID}\n" +
                            $"|Address: {Address}\n" +
                            $"|---------------------\n";
            return output;
        }
        
    }
}