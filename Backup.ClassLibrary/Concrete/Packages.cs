using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Backup.ClassLibrary.Models;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Concrete.Security;
using System.Data;
using System.Net.Http;
using Backup.ClassLibrary.Concrete.Nakivo;

namespace Backup.ClassLibrary.Concrete
{
    public class Packages : IPackages
    {
        private BackOfficeDB db = new BackOfficeDB();
        private List<vBOviewInvoiceTab> InvoicesDetail;
        private List<vBOviewInvoiceTab> InvoicesDetail_Rep;

        public IEnumerable<v_PackageTap> getAllPackages
        {
            get { return db.v_PackageTap; }
        }

        public IEnumerable<Package_Type> getAllTypePackages
        {
            get { return db.Package_Type; }
        }
        



        public IEnumerable<vBOviewInvoiceTab> addCreditInvoiceBackup(m_create_inv_backup value)
        {
            try
            {
                VeeamCC vm = new VeeamCC();
                string password = Util.Util.PasswordGenerate(10, false, true);
                int day_pck = 30;
                if (value.pck_type == 11) day_pck = 30;//1 month
                else if (value.pck_type == 111) day_pck = 90;//3 month
                else if (value.pck_type == 112) day_pck = 180;//6 month
                else if (value.pck_type == 113) day_pck = 360;//12 month
                App_Securities sec = new App_Securities();
                var key_pair = sec.ImportKeys();

                if (key_pair == null) { return null; }

                var pass_hash = sec.Encrypt(password);

                // Create Package to DB
                var result = db.Database.SqlQuery<vBOviewInvoiceTab>("[backup].[s_EnterpriseCreatePackageBackUp] @cust_id, @vm, @storage, @premiums_storage, @free_trial, @password,@pck_type",
                    new SqlParameter("@cust_id", value.cust_id),
                    new SqlParameter("@vm", value.vmQty),
                    new SqlParameter("@storage", value.storage),
                    new SqlParameter("@premiums_storage", value.premiums_storage),
                    new SqlParameter("@free_trial", value.free_trial),
                    new SqlParameter("@password", pass_hash),
                    new SqlParameter("@pck_type", value.pck_type));

                InvoicesDetail = result.ToList();
                
                bool success_create = false;

                if (result != null && InvoicesDetail[0].password.Equals(pass_hash))
                {
                    string tenantName = InvoicesDetail[0].username;

                    success_create = vm.CreateTenant(tenantName, password, DateTime.Now.Date.AddDays(day_pck), value.storage);

                    string UIDs = vm.getUIDTenantByTenantName(tenantName);

                    Guid UID = Guid.Parse(UIDs);

                    List<SqlParameter> paramsReq = new List<SqlParameter>()
                    {
                        new SqlParameter() {ParameterName = "@tenantname", SqlDbType = SqlDbType.NVarChar, Value= tenantName},
                        new SqlParameter() {ParameterName = "@tenant_id", SqlDbType = SqlDbType.UniqueIdentifier, Value = UID},
                    };

                    var affectedRow = db.Database.ExecuteSqlCommand("[backup].[s_UpdateVeeamTenant] @tenantname, @tenant_id", paramsReq.ToArray());
                }

                return InvoicesDetail;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }
        public IEnumerable<vBOviewInvoiceTab> addCreditInvoiceNakivoBackup(m_create_inv_backup value)
        {
            try
            {
                NakivoAPI api = new NakivoAPI();
                string password = Util.Util.PasswordGenerate(10, false, true);
                int day_pck = 30;
                if (value.pck_type == 13) day_pck = 30;//1 month
                else if (value.pck_type == 131) day_pck = 90;//3 month
                else if (value.pck_type == 132) day_pck = 180;//6 month
                else if (value.pck_type == 133) day_pck = 360;//12 month
                App_Securities sec = new App_Securities();
                var key_pair = sec.ImportKeys();

                if (key_pair == null) { return null; }

                var pass_hash = sec.Encrypt(password);

                // Create Package to DB
                var result = db.Database.SqlQuery<vBOviewInvoiceTab>("[backup].[s_EnterpriseCreatePckNakivoBackUp] @cust_id, @vm, @storage, @premiums_storage, @free_trial, @password,@pck_type",
                    new SqlParameter("@cust_id", value.cust_id),
                    new SqlParameter("@vm", value.vmQty),
                    new SqlParameter("@storage", value.storage),
                    new SqlParameter("@premiums_storage", value.premiums_storage),
                    new SqlParameter("@free_trial", value.free_trial),
                    new SqlParameter("@password", pass_hash),
                    new SqlParameter("@pck_type", value.pck_type));

                InvoicesDetail = result.ToList();

                bool success_create = false;

                if (result != null && InvoicesDetail[0].password.Equals(pass_hash))
                {
                    string tenantName = InvoicesDetail[0].username;

                    // success_create = vm.CreateTenant(tenantName, password, DateTime.Now.Date.AddDays(30), value.storage);
                    var connection = api.ConnectNakivo_API();
                    var res = api.CreateTenant(connection, tenantName, password, null, null, null, value.vmQty, value.storage, (value.premiums_storage == 1 ? true:false) );
                    var tn = api.getTenantByName(connection, tenantName);
                    string UIDs = api.getUID(tn);

                    Guid UID = Guid.Parse(UIDs);

                    List<SqlParameter> paramsReq = new List<SqlParameter>()
                    {
                        new SqlParameter() {ParameterName = "@tenantname", SqlDbType = SqlDbType.NVarChar, Value= tenantName},
                        new SqlParameter() {ParameterName = "@tenant_id", SqlDbType = SqlDbType.UniqueIdentifier, Value = UID},
                    };

                    var affectedRow = db.Database.ExecuteSqlCommand("[backup].[s_UpdateVeeamTenant] @tenantname, @tenant_id", paramsReq.ToArray());
                }

                return InvoicesDetail;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }

        public getTotalAmountPck PackageCalculator(int vm, int storage, bool preniums_storage, int pck_type = 11)
        {
            if(pck_type == 13)
            {
                var s = db.Database.SqlQuery<getTotalAmountPck>("SELECT * FROM [backup].[f_Nakivo_BackupPck_Cal] (@vm, @storage, @preniums_storage)",
                    new SqlParameter("@vm", vm),
                    new SqlParameter("@storage", storage),
                    new SqlParameter("@preniums_storage", preniums_storage)).Single();

                if (pck_type == 13)
                {
                    return s;
                }
                var qry = db.Products_Price.FirstOrDefault(q => q.pck_type_id == pck_type);
                s.total_price = (s.total_price * qry.quantity) - ((s.total_price * qry.quantity) * (qry.price/100));
                return s;
            }
            else
            {
                var s = db.Database.SqlQuery<getTotalAmountPck>("SELECT * FROM [backup].[f_BackupPck_Cal] (@vm, @storage, @preniums_storage)",
                    new SqlParameter("@vm", vm),
                    new SqlParameter("@storage", storage),
                    new SqlParameter("@preniums_storage", preniums_storage)).Single();

                if (pck_type == 11)
                {
                    return s;
                }
                var qry = db.Products_Price.FirstOrDefault(q => q.pck_type_id == pck_type);
                s.total_price = (s.total_price * qry.quantity) - ((s.total_price * qry.quantity) * (qry.price/100));
                return s;
            }
        }

        public IEnumerable<vBOviewInvoiceTab> addCreditInvoiceReplication(m_create_inv_replication value)
        {
            bool success_create = false;
            try
            {
                VccReplication vm = new VccReplication();
                string password = Util.Util.PasswordGenerate(10, false, true);
                int day_pck = 30;
                if (value.pck_type == 12) day_pck = 30;//1 month
                else if (value.pck_type == 121) day_pck = 90;//3 month
                else if (value.pck_type == 122) day_pck = 180;//6 month
                else if (value.pck_type == 123) day_pck = 360;//12 month
                App_Securities sec = new App_Securities();
                var key_pair = sec.ImportKeys();

                if (key_pair == null) { return null; }

                var pass_hash = sec.Encrypt(password);

                // Create Package to DB
        var result = db.Database.SqlQuery<vBOviewInvoiceTab>("[backup].[s_EnterpriseCreatePackageReplication] @cust_id, @vm, @storage,@processor,@ram,@ipaddress,@networks,@internet_traffic, @premiums_storage, @free_trial, @password,@pck_type",
                    new SqlParameter("@cust_id", value.cust_id),
                    new SqlParameter("@vm", value.vmQty),
                    new SqlParameter("@storage", value.storage),
                    new SqlParameter("@processor", value.processor),
                    new SqlParameter("@ram", value.ram),
                    new SqlParameter("@ipaddress", value.ipaddress),
                    new SqlParameter("@networks", value.networks),
                    new SqlParameter("@internet_traffic", value.internet_traffic),
                    new SqlParameter("@premiums_storage", value.premiums_storage),
                    new SqlParameter("@free_trial", value.free_trial),
                    new SqlParameter("@password", pass_hash),
                    new SqlParameter("@pck_type", value.pck_type));

                InvoicesDetail_Rep = result.ToList();

               

                if (result != null && InvoicesDetail_Rep[0].password.Equals(pass_hash))
                {
                    string tenantName = InvoicesDetail_Rep[0].username.Substring(3);
                    HttpClient connectVcc = vm.ConnectVCC_API();
                    var createHW = vm.Set_CloudHardwarePlanCreateSpec(tenantName, value.processor*1024, value.ram*1024, value.storage, value.networks);
                    StringContent HWScript = vm.Cv_CloudHardwarePlanCreateSpecToXmlStr(createHW);
                    var createHWResponse = vm.Post_CreateHardwarePlan(connectVcc, HWScript);
                    System.Threading.Thread.Sleep(8000);
                    var HWID = vm.Get_UIDbyHardwareName(connectVcc, tenantName);
                    System.Threading.Thread.Sleep(2000);
                    string tenantUID = "";

                    if (HWID != null) {
                        var createTenant = vm.New_CreateCloudTenantRepSpec("VCC"+tenantName, password, HWID.Replace("urn:veeam:CloudHardwarePlan:", ""),day_pck);
                        var tenantContent = vm.Cv_CreateCloudTenantSpecToXmlStr(createTenant);
                        var createTenantRes = vm.Post_CreateTenant(connectVcc, tenantContent);
                        System.Threading.Thread.Sleep(8000);
                        tenantUID = vm.Get_UIDByTenantName(connectVcc, "VCC"+tenantName);
                        if (tenantUID != null)
                        {
                            Guid t_id = new Guid(tenantUID.Substring(22, 36));
                            var Row = db.Database.ExecuteSqlCommand("UPDATE [backup].[Veeam_Tenant] SET tenant_id = @tenant_id WHERE vcc_id = @tenantname",
                                new SqlParameter("@tenantname", tenantName),
                                new SqlParameter("@tenant_id", t_id)
                               );
                            success_create = true;
                        }
                    }

                }

                return success_create == true ? InvoicesDetail_Rep: null;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }

        public getTotalAmountPck_rep PackageCalculatorReplication(PackageCalculator_rep req)
        {
            var i = 0;
            var s = db.Database.SqlQuery<getTotalAmountPck_rep>("SELECT * FROM [backup].[f_ReplicationPck_Cal] (@vm, @storage, @processor,@ram,@ipaddress,@networks,@internet_traffic)",
             new SqlParameter("@vm", req.vm),
             new SqlParameter("@storage", req.storage),
             new SqlParameter("@processor",i ),
             new SqlParameter("@ram", i),
             new SqlParameter("@ipaddress", req.ip_address),
             new SqlParameter("@networks", req.networks),
             new SqlParameter("@internet_traffic", i)
             ).Single();

            if (req.pck_type == 12)
            {
                return s;
            }
            var qry = db.Products_Price.FirstOrDefault(q => q.pck_type_id == req.pck_type);
            s.total_price = (s.total_price * qry.quantity) - ((s.total_price * qry.quantity) * (qry.price/100));
            return s;
        }

        public Customer_Notification GetCustomer_Notification(int id)
        {
            var cust = db.Customer_Notification.FirstOrDefault(c => c.cust_id == id);
            return cust;
        }

        public IEnumerable<Veeam_Tenant> Post_Veeam_Tenant_Block(BO_Packages_Block value)
        {
            var s = db.Database.SqlQuery<Veeam_Tenant>("SELECT * FROM [backup].[Veeam_Tenant] AS v WHERE v.vcc_id=@vcc_id",
               new SqlParameter("@vcc_id", value.vcc_id)).ToList();
            return s;
        }

        public IEnumerable<Cart> Post_Cart_Block(BO_Packages_Block value)
        {
            var s = db.Database.SqlQuery<Cart>("SELECT * FROM [backup].[Cart] AS v WHERE v.cart_id=@cart_id AND v.cust_id=@cust_id",
               new SqlParameter("@cart_id", value.cart_id),
               new SqlParameter("@cust_id", value.cust_id)).ToList();
            return s;
        }

        public IEnumerable<Packages2> Post_Packages_Block(BO_Packages_Block value)
        {
            var s = db.Database.SqlQuery<Packages2>("SELECT * FROM [backup].[Packages] AS v WHERE v.cart_id=@cart_id AND v.cust_id=@cust_id",
               new SqlParameter("@cart_id", value.cart_id),
               new SqlParameter("@cust_id", value.cust_id)).ToList();
            return s;
        }

        public IEnumerable<v_PackageTap_viewReport> GetPackageByrefId(int id_ref)
        {
            return db.v_PackageTap_viewReport.Where(c => c.id_ref == id_ref).ToList();
        }

        public IEnumerable<Veeam_Tenant> GetPackageVeeam_Tenant(int id_pck)
        {
            return db.Veeam_Tenant.Where(c => c.pck_id == id_pck).ToList();
        }
    }
}


public class vDATA {
    public int vcc_id { get; set; }
    public int cust_id { get; set; }
    public int pck_id { get; set; }
}
