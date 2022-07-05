using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Concrete
{
    public class Policy : Ipolicy
    {
        private BackOfficeDB db = new BackOfficeDB();

        public IEnumerable<v_Products_Price> product_price { get { return db.v_Products_Price; } }

        public bool change_policy(int product_id, decimal price)
        {
            var qry = db.Products_Price.FirstOrDefault(p => p.products_id == product_id);
            qry.price = price;
            qry.update_dt = DateTime.Now;
            var res = db.SaveChanges();
            return res > 0 ? true : false;

        }

        public bool change_unit(int product_id, string unit)
        {
            var qry = db.Products_Price.FirstOrDefault(p => p.products_id == product_id);
            qry.unit = unit;
            qry.update_dt = DateTime.Now;
            var res = db.SaveChanges();
            return res > 0 ? true : false;

        }
    }
}
