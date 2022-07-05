using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Concrete
{
    public class PromoCode : IPromoCode
    {
        private BackOfficeDB db = new BackOfficeDB();
        public IEnumerable<Promo_code> GetAll()
        {
            return db.Promo_code.Where(x => x.staus != "rm").OrderBy(x => x.add_dt);
        }

        public Promo_code GetById(int Id)
        {
            return db.Promo_code.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public IEnumerable<v_GetPackage_manage> GetPromoHistory
        {
            get { return db.v_GetPackage_manage; }
        }

        public bool insert(string Promo_code, float discount, DateTime expired_dt)
        {
            var res = db.Database.ExecuteSqlCommand("INSERT INTO [9t_all].[Promo_code](promo_code, discount, expired_dt, add_dt) VALUES (@Promo_code, @discount, @expired_dt, @add_dt)",
                new SqlParameter("@Promo_code", Promo_code),
                new SqlParameter("@discount", discount),
                new SqlParameter("@expired_dt", expired_dt),
                new SqlParameter("@add_dt", DateTime.Now)
                );

            return res > 0 ? true : false;
        }

        public bool Remove(int Id)
        {
            var res = db.Database.ExecuteSqlCommand(" UPDATE [9t_all].[Promo_code] SET staus = 'rm' WHERE Id = @Id",
                new SqlParameter("@Id", Id)
                );

            return res > 0 ? true : false;
        }

        public bool update(int Id, string Promo_code, float discount, DateTime expired_dt)
        {
            var res = db.Database.ExecuteSqlCommand("UPDATE [9t_all].[Promo_code] SET promo_code = @Promo_code, discount = @discount, expired_dt = @expired_dt WHERE Id = @Id",
                new SqlParameter("@Promo_code", Promo_code),
                new SqlParameter("@discount", discount),
                new SqlParameter("@expired_dt", expired_dt),
                new SqlParameter("@Id", Id)
                );

            return res > 0 ? true : false;
        }

        public bool check(string Promo_code)
        {
            var er = db.Promo_code.Where(x => x.promo_code.Equals(Promo_code));

            return er.Count() == 0 ? true : false;
        }

        public Promo_code GetByPromo_code(string promo_code)
        {
            var er = db.Promo_code.Where(x => x.promo_code.Equals(promo_code)).FirstOrDefault();

            return er;
        }

        public bool checkupdate(string promo_code, int Id)
        {
            var cu = db.Promo_code.Where(x => x.promo_code.Equals(promo_code));
            var t = cu.FirstOrDefault(x => x.Id != Id);

            return t == null ? true : false;
        }
    }
}
