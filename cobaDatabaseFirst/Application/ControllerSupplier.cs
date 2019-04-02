using cobaDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cobaDatabaseFirst
{
    public class ControllerSuppliers : DataManipulation, ISupplier
    {        
        static MyContext myContext = new MyContext();
        //private ControllerSuppliers controllerSupplier = new ControllerSuppliers();
        DataManipulation dataManipulation = new DataManipulation(myContext);
        bool status = false;

        public ControllerSuppliers(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public ControllerSuppliers() { }

        public List<TB_M_Suppliers> Get()
        {
            var get = myContext.TB_M_Suppliers.Where(x => x.IsDelete == false).ToList();            
            foreach (var list in get)
            {
                Console.Write("Id : ");
                Console.WriteLine(list.Id);
                Console.Write("Name : ");
                Console.WriteLine(list.Name);
            }
            return get;
        }

        public bool InsertData()
        {
            string Name;
            Console.Write("Insert Suppliers name : ");
            Name = Console.ReadLine();
            TB_M_Suppliers suppliers = new TB_M_Suppliers();
            suppliers.Name = Name;
            myContext.TB_M_Suppliers.Add(suppliers);            
            return dataManipulation.Save(myContext);
        }

        public bool EditData(int Id)
        {
            string Name;
            var supplier = Get(Id);
            //var get2 = MyCon.TB_M_Supplierss.SingleOrDefault(x => x.Id == Id);
            if (supplier != null)
            {
                Console.Write("Insert new name : ");
                Name = Console.ReadLine();
                supplier.Name = Name;
                myContext.Entry(supplier).State = EntityState.Modified;
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
            var supplier = Get(Id);
            //var get2 = MyCon.TB_M_Supplierss.SingleOrDefault(x => x.Id == Id);
            if (supplier != null)
            {
                supplier.IsDelete = true;
                myContext.Entry(supplier).State = EntityState.Modified;
                return dataManipulation.Save(myContext);                
            }
            else
            {
                Console.Write("No Data Found");                
            }
            return status;
        }

        public TB_M_Suppliers Get(int Id)
        {
            var get = myContext.TB_M_Suppliers.Find(Id);            
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
