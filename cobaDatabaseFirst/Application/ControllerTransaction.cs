using cobaDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cobaDatabaseFirst.Application
{
    class ControllerTransaction : DataManipulation
    {
        static MyContext myContext = new MyContext();
        DataManipulation dataManipulation = new DataManipulation(myContext);

        public ControllerTransaction(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public ControllerTransaction() { }

        public int SaveDate()
        {
            TB_M_Sell sell = new TB_M_Sell();
            sell.OrderDate = DateTime.Now;
            myContext.TB_M_Sell.Add(sell);
            dataManipulation.Save(myContext);
            return sell.Id;
        }

        public TB_M_Sell Get(int id)
        {
            var get = myContext.TB_M_Sell.SingleOrDefault(x => x.Id == id);
            return get;
        }

        public bool BeliBarang(int itemId, int quantity)
        {
            ControllerItem controllerItem = new ControllerItem(myContext);
            int sell = SaveDate();
            TB_T_Detail detail = new TB_T_Detail();            
            detail.Amount = quantity;
            detail.TB_M_Item = controllerItem.Get(itemId);
            detail.TB_M_Sell = Get(sell);
            myContext.TB_T_Detail.Add(detail);
            return dataManipulation.Save(myContext);
        }
    }
}
