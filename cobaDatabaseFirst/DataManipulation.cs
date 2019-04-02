using cobaDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cobaDatabaseFirst
{
    public class DataManipulation
    {
        public static MyContext myContext = new MyContext();
        
        public DataManipulation(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public DataManipulation() { }

        public bool Save(MyContext myContext)
        {
            bool status;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;     
                Console.WriteLine("Operation Success");
            }
            else
            {
                status = false;
                Console.WriteLine("Operation failed");
            }
            return status;
        }        
    }
}
