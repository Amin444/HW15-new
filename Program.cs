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
             TimerCallback timer = new TimerCallback(CheckBalance);
            Timer tm = new Timer(timer, CustomerList, 0, 10000);

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
                    Thread ThreadInsert=new Thread(new ThreadStart(Insert));
                    ThreadInsert.Start();
                    ThreadInsert.Join();
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
              decimal LastBalance = Balance;
            Customer UserInsert=new Customer(id ,Balance,LastBalance);
            CustomerList.Add(UserInsert);
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

          public static void CheckBalance(object p)
        {
            int i = 0;
            foreach (var x in CustomerList)
            {
                if (x.Balance > x.LastBalance)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" Client ID {x.id}  balance after changed is {x.Balance} > {x.LastBalance} <- this is last balance  [+]");
                    CustomerList[i].LastBalance = CustomerList[i].Balance;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (x.Balance < x.LastBalance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Client ID {x.id} balance after changed is {x.Balance} < {x.LastBalance} <- this is last balance [-]");
                    CustomerList[i].LastBalance = CustomerList[i].Balance;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                i++;
            }
        }

    }



    class Customer
    {
        public int id {get;set;}
        public decimal Balance{ get; set; }
        public decimal LastBalance{get;set;}

        public Customer(int id, decimal Balance,decimal LastBalance)
        {
            this.id=id;
            this.Balance=Balance;
            this.LastBalance=LastBalance;
        }
        public Customer()
        {

        }
    }
}
