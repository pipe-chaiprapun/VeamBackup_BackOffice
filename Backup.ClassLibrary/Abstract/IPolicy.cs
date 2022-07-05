using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface Ipolicy
    {
        IEnumerable<v_Products_Price> product_price { get; }

        bool change_policy(int product_id, decimal price);

        bool change_unit(int product_id, string unit);
    }
}
