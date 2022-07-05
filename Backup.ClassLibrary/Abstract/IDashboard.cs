using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Abstract
{
    public interface IDashboard
    {
        IEnumerable<m_Dashboard> qry_Dashboard_quick(string value);
        IEnumerable<m_Dashboard> qry_Dashboard_from(string from, string to);
    }
}
