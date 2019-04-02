using cobaDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cobaDatabaseFirst
{
    interface ISupplier
    {
        List<TB_M_Suppliers> Get();
        bool InsertData();
        bool EditData(int Id);
        bool DeleteData(int Id);
        TB_M_Suppliers Get(int Id);
    }
}
