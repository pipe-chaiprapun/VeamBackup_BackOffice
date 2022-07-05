using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Abstract
{
    public interface IPromoCode
    {
        bool insert(string Promo_code, float discount, DateTime expired_dt);
        IEnumerable<Promo_code> GetAll();
        Promo_code GetById(int Id);
        bool update(int Id, string Promo_code, float discount, DateTime expired_dt);
        bool Remove(int Id);
        bool check(string promo_code);
        Promo_code GetByPromo_code(string promo_code);
        bool checkupdate(string promo_code, int Id);
        IEnumerable<v_GetPackage_manage> GetPromoHistory { get; }
    }
}
