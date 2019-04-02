using cobaDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cobaDatabaseFirst
{
    public interface IItem
    {
        List<TB_M_Item> Get();
        bool InsertData();
        bool EditData();
        bool DeleteData(int Id);
        TB_M_Item Get(int Id);
    }
}
