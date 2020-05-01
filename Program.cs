using System;
using System.Threading;
using System.Collections.Generic;

namespace HW15_new
{
    class Program
    {
     public static List<Customer> CustomerList = new List<Customer>();
        static void Main(string[] args)
        {
         
        }
        
    }
    class Customer
    {
        public int id {get;set;}
        public decimal Balance{ get; set; }

        public Customer(int id, decimal Balance)
        {
            this.id=id;
            this.Balance=Balance;
        }
        public Customer()
        {

        }
    }
}
