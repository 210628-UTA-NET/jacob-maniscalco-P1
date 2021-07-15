using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StoreModels {
    public class Customer 
    {

        private int _id;
        private string _name;
        private string _address;
        private string _phoneNumber;
        private List<Order> _orders;
        public Customer()
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
        public string PhoneNumber 
        { 
            get
            {
                return _phoneNumber;
            } 
            set
            {
                if(!Regex.IsMatch(value, @"^\d{10}$"))
                {
                    throw new System.Exception("Incorrect phone number format.");
                }
                _phoneNumber = value;
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