using cobaDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cobaDatabaseFirst
{
    public class ControllerItem : DataManipulation, IItem
    {
        static MyContext myContext = new MyContext();        
        DataManipulation dataManipulation = new DataManipulation(myContext);
        bool status = false;

        public ControllerItem(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public ControllerItem() { }

        public List<TB_M_Item> Get()
        {
            var get = myContext.TB_M_Item.Where(x => x.IsDelete == false).ToList();
            foreach (var list in get)
            {
                Console.Write("Id : ");
                Console.WriteLine(list.Id);
                Console.Write("Name : ");
                Console.WriteLine(list.Name);
                Console.Write("Quantity : ");
                Console.WriteLine(list.Quantity);
                Console.Write("Price : ");
                Console.WriteLine(list.Price);
            }
            return get;
        }

        public bool InsertData()
        {
            string Name, SupplierName;
            int Quantity, Price;
            Console.Write("Insert Item name : ");
            Name = Console.ReadLine();
            Console.Write("Insert Item Quantity : ");
            Quantity = Convert.ToInt16(Console.ReadLine());
            Console.Write("Insert Item Price : ");
            Price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Insert supplier name : ");
            SupplierName = Console.ReadLine();
            var sup_id = myContext.TB_M_Suppliers.Single(x => x.Name.Contains(SupplierName) && x.IsDelete == false);
            if(sup_id != null)
            {
                TB_M_Item item = new TB_M_Item();
                item.Name = Name;
                item.Quantity = Quantity;
                item.Price = Price;
                item.TB_M_Suppliers = sup_id;
                myContext.TB_M_Item.Add(item);
                return dataManipulation.Save(myContext);
            }
            else
            {
                Console.WriteLine("Supplier tidak ditemukan");
                return status;
            }
        }

        public bool EditData()
        {                        
            string Name;
            int Quantity, Price, Id;            
            Console.Write("Insert the Id : ");            
            Id = Convert.ToInt16(Console.ReadLine());
            var get = Get(Id);
            //var get2 = MyCon.TB_M_Items.SingleOrDefault(x => x.Id == Id);
            if (get != null)
            {
                Console.Write("Insert new name : ");
                Name = Console.ReadLine();
                Console.Write("Insert Item Quantity : ");
                Quantity = Convert.ToInt16(Console.ReadLine());
                Console.Write("Insert Item Price : ");
                Price = Convert.ToInt32(Console.ReadLine());
                get.Name = Name;
                get.Quantity = Quantity;
                get.Price = Price;
                myContext.Entry(get).State = EntityState.Modified;
                return dataManipulation.Save(myContext);
            }
            else
            {
                Console.Write("No Data Found");
                status = false;
            }
            return status;
        }

        public bool DeleteData(int Id)
        {
            var get = Get(Id);
            //var get2 = MyCon.TB_M_Items.SingleOrDefault(x => x.Id == Id);
            if (get != null)
            {
                get.IsDelete = true;
                myContext.Entry(get).State = EntityState.Modified;
                return dataManipulation.Save(myContext);                
            }
            else
            {
                Console.Write("No Data Found");
            }
            return status;
        }

        public TB_M_Item Get(int Id)
        {
            var get = myContext.TB_M_Item.Find(Id);
            if (get != null)
            {
                return get;
            }
            else
            {
                return null;
            }
        }
    }
}
