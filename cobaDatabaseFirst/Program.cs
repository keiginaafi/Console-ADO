using cobaDatabaseFirst.Application;
using cobaDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cobaDatabaseFirst
{
    class Program
    {
        static Program program = new Program();               
        static MyContext myContext = new MyContext();
        static void Main(string[] args)
        {            
            //Console.Write("Hello World");            
            program.Menu();            
        }


        public void Menu()
        {
            int choice;
            Console.WriteLine("==============================");
            Console.WriteLine("||      Menu Transaksi      ||");
            Console.WriteLine("==============================");
            Console.WriteLine("||       1. Supplier        ||");
            Console.WriteLine("||         2. Item          ||");
            Console.WriteLine("||      3. Beli Barang      ||");
            Console.WriteLine("||    4. Ubah transaksi     ||");
            Console.WriteLine("==============================");
            Console.Write("Pilihanmu : ");
            choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    program.MenuSupplier();
                    break;
                case 2:
                    program.MenuItem();
                    break;
                case 3:
                    program.MenuBeli();
                    break;
                default:
                    Console.WriteLine("Exiting....");
                    Console.Read();
                    break;
            }
            //return choice;
        }

        public void MenuSupplier()
        {
            int choice, id;
            ISupplier controllerSupplier = new ControllerSuppliers();
            Console.WriteLine("==============================");
            Console.WriteLine("||       Menu Supplier      ||");
            Console.WriteLine("==============================");
            Console.WriteLine("||       1. View All        ||");
            Console.WriteLine("||    2. Insert new data    ||");
            Console.WriteLine("||       3. Edit data       ||");
            Console.WriteLine("||      4. Delete data      ||");
            Console.WriteLine("==============================");
            Console.Write("Pilihanmu : ");
            choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    controllerSupplier.Get();
                    Console.Read();
                    break;
                case 2:
                    controllerSupplier.InsertData();
                    Console.Read();
                    break;
                case 3:
                    Console.Write("Insert the Id : ");
                    id = Convert.ToInt16(Console.ReadLine());
                    controllerSupplier.EditData(id);
                    Console.Read();
                    break;
                case 4:
                    Console.WriteLine("Insert supplier Id : ");
                    id = Convert.ToInt16(Console.ReadLine());
                    controllerSupplier.DeleteData(id);
                    Console.Read();
                    break;
                default:
                    Console.WriteLine("Exiting....");
                    Console.Read();
                    break;
            }
            //return choice;
        }

        public void MenuItem()
        {
            int choice, id;
            IItem controllerItem = new ControllerItem();
            Console.WriteLine("==============================");
            Console.WriteLine("||         Menu Item        ||");
            Console.WriteLine("==============================");
            Console.WriteLine("||       1. View All        ||");
            Console.WriteLine("||    2. Insert new data    ||");
            Console.WriteLine("||       3. Edit data       ||");
            Console.WriteLine("||      4. Delete data      ||");
            Console.WriteLine("==============================");
            Console.Write("Pilihanmu : ");
            choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    controllerItem.Get();
                    Console.Read();
                    break;
                case 2:
                    controllerItem.InsertData();
                    Console.Read();
                    break;
                case 3:
                    Console.Write("Insert the Id : ");
                    id = Convert.ToInt16(Console.ReadLine());
                    controllerItem.EditData();
                    Console.Read();
                    break;
                case 4:
                    Console.WriteLine("Insert supplier Id : ");
                    id = Convert.ToInt16(Console.ReadLine());
                    controllerItem.DeleteData(id);
                    Console.Read();
                    break;
                default:
                    Console.WriteLine("Exiting....");
                    Console.Read();
                    break;
            }
            //return choice;
        }

        public void MenuBeli()
        {
            ControllerTransaction controllerTransaction = new ControllerTransaction(myContext);
            ControllerItem controllerItem = new ControllerItem();
            controllerItem.Get();
            controllerTransaction.BulkPurchase();
            //Console.Write("Kode barang yang ingin dibeli : ");
            //int itemId = Convert.ToInt16(Console.ReadLine());
            //Console.Write("Insert your quantity : ");
            //int quantity = Convert.ToInt16(Console.ReadLine());

            ////controllerTransaction.SaveDate();
            //controllerTransaction.BeliBarang(itemId, quantity);            
            Console.Read();
        }
    }
}
