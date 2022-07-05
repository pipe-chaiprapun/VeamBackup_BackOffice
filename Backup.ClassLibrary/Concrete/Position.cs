using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete
{
    public class Position : IPosition
    {
        private BackOfficeDB db = new BackOfficeDB();
        public IEnumerable<BO_Position> getPositionAll
        {
            get { return db.BO_Position; }
        }
    }
}
