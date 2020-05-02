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
           Console.Clear();
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

                case 3:
                {
                    Thread ThreadSelect =new Thread(new ThreadStart(Select));
                    ThreadSelect.Start();
                    ThreadSelect.Join();
                }break;

                case 4:
                {
                    Thread ThreadUpdate =new Thread(new ThreadStart(Update));
                    ThreadUpdate.Start();
                    ThreadUpdate.Join();
                }break;

                case 5:
                {
                     Thread ThreadDelete =new Thread(new ThreadStart(Delete));
                    ThreadDelete.Start();
                    ThreadDelete.Join();
                }break;
                case 6:{b=false;}break;
             }

          }




        }

        public static void Insert()
        {
           
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
             Console.Clear();
            System.Console.WriteLine("Loading...");
            Thread.Sleep(3000);
            Console.Clear();
            foreach(var Customer in CustomerList)
            {
                System.Console.WriteLine($"Customer id ->{Customer.id} and Balance-> {Customer.Balance}");
            }
                string stop=Console.ReadLine();

        }
        public static void Update()
        {
            Console.Clear();
            System.Console.WriteLine("If you want to Changes please write new meaning");
            decimal balance =decimal.Parse(Console.ReadLine());
            foreach (var  Customer in CustomerList)
            {
                Customer.Balance=balance;
            }

        }
        public static void Delete()
        {
                int DeleteId =int.Parse(Console.ReadLine());
                foreach(var Customer in CustomerList)
                {
                    if(DeleteId==Customer.id)
                    {
                        CustomerList.Remove(Customer);
                        System.Console.WriteLine($"your id {DeleteId} was delete successful");
                    }
                }
            
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
