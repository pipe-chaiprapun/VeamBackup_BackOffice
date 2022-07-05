using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;

namespace Backup.ClassLibrary.Abstract
{
    public interface IRequestNewPackage
    {
        IEnumerable<VBackupBackOfficeRequestsNewPackage> getallPackage { get; }
        string RemoveReuestPackage(int id);
    }
}
