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
          System.Console.WriteLine("Welcome into Clients Base");
          bool b =true;
          while(b)
          {

          System.Console.WriteLine("What i can ->-v");
          System.Console.WriteLine("1->Add ypur id and Balance");
          System.Console.WriteLine("3->Select your id and Balance");
          System.Console.WriteLine("4-> Update your id and Balance");
          System.Console.WriteLine("5-> Delete your id and Balance");
          System.Console.WriteLine("6 -> exit in Console");

              int choise = int.Parse(Console.ReadLine()); 
             switch(choise)
             {
                case 1:
                {
                    Thread InsertThread =new Thread(Insert);
                    InsertThread.Start();
                    InsertThread.Join();
                }break;

             }
          }


        }

        public static void Insert()
        {
            Console.Clear();
            System.Console.WriteLine("Loading...");
            Thread.Sleep(3000);
            Console.Clear();
            System.Console.WriteLine("Please Complate form ");
            System.Console.Write("Write your id: ");
            int id = int.Parse(Console.ReadLine());
            System.Console.WriteLine("================================");
            System.Console.Write("Write ypur Balance:");
            decimal Balance = decimal.Parse(Console.ReadLine());

        }

        public static void Select()
        {

        }
        public static void Update()
        {

        }
        public static void Delete()
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
