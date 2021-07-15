using System;
using System.Collections.Generic;

namespace StoreModels {
    public class StoreFront 
    {

        private int _id;
        private string _name;
        private string _address;
        private List<LineItem> _inventory;
        private List<Order> _orders;
        public StoreFront()
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
        public string Address 
        { 
            get
            {
                return _address;
            } 
            set
            {
                _address = value;
            } 
        }
        public List<LineItem> Inventory 
        { 
            get
            {
                return _inventory;
            } 
            set
            {
                _inventory = value;
            } 
        }
        public List<Order> Orders 
        { 
            get
            {
                return _orders;
            } 
            set
            {
                _orders = value;
            } 
        }

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