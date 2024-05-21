using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IVending
    {
        Product Purchase(int productId);
        List<string> ShowAll();
        string Details(int productId);
        void InsertMoney(int amount);
        Dictionary<int, int> EndTransaction();
    } 
}
