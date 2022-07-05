using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Abstract
{
    public interface IOption
    {
        IEnumerable<Option9T> GetAll();
        Option9T GetById(string option_code);
        bool Option_code(int Id, bool use);


        
    }
}
