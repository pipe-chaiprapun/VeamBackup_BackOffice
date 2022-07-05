using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Abstract
{
    public interface IRequestsHistory
    {
        IEnumerable<VBackOfficeRequestsHistory> getAllRequestsHistory { get; }
        string RemoveReuestHistory(int id);

    }
}
