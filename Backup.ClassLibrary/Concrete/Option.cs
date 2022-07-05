using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Concrete
{
    public class Option : IOption
    {
        private BackOfficeDB db = new BackOfficeDB();
        public IEnumerable<Option9T> GetAll()
        {
             return db.Option9T; 
        }

        public Option9T GetById(string option_code)
        {
            return db.Option9T.Where(x => x.Option_code.Equals(option_code)).FirstOrDefault();
        }

        public bool Option_code(int Id, bool use)
        {
            var qr = db.Option9T.Where(x => x.Id == Id).FirstOrDefault();
            if (qr != null) {
                qr.use = use;
                qr.update_dt = DateTime.Now;
                int qe = db.SaveChanges();
                return qe > 0 ? true : false;

            }

            return false;
        }
    }
}
