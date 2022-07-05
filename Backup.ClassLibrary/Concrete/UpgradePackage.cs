using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.ClassLibrary.Models;
using System.Net.Http;
using System.Xml;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using Backup.ClassLibrary.Entity;

namespace Backup.ClassLibrary.Concrete
{
    public class UpgradePackage : IUpgradePackage
    {
        private BackOfficeDB db = new BackOfficeDB();

        public IEnumerable<getPackageFromCart> getUpgradeForPackage()
        {
            var res = db.Database.SqlQuery<getPackageFromCart>("EXEC [backup].[s_BO_GetPackage]").ToList();
            return res;
        }
        #region upgrade package old from 9/11/2017
        public string getUIDTenantByTenantName(string TenantName)
        {
            Rootobject Tenants = new Rootobject();
            Tenants = getCloudTenantsEntity();
            var s = Tenants.EntityReferences.Ref.Where(x => x.Name.Equals(TenantName)).FirstOrDefault();
            string b = s.UID;
            return Regex.Replace(b, "urn:veeam:CloudTenant:", string.Empty, RegexOptions.IgnoreCase);
        }
        public Rootobject getCloudTenantsEntity()
        {
            Rootobject data;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.50.18.4:9399");
                client.DefaultRequestHeaders.Add("Authorization", "Basic VmVlYW1BcGk6QWRkbGluazEyMyE=");
                HttpResponseMessage sessionResponse = client.PostAsync("/api/sessionMngr/?v=v1_3", null).Result;
                XmlDocument sessionResponseDoc = new XmlDocument();
                sessionResponseDoc.LoadXml(sessionResponse.Content.ReadAsStringAsync().Result);
                sessionResponseDoc.DocumentElement.RemoveAllAttributes();
                var s = sessionResponse.Headers.Where(x => x.Key == "X-RestSvcSessionId").FirstOrDefault().Value.First();

                System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                client.DefaultRequestHeaders.Add("X-RestSvcSessionId", s);
                string response = client.GetStringAsync("/api/cloud/tenants").Result;
                var jsonObjects = ConvertXml2Json(response);
                data = JsonConvert.DeserializeObject<Rootobject>(jsonObjects);
            }
            return data;
        }
        public CloudTenant getCloudTenantsByUID(string UID)
        {
            CloudTenant data;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.50.18.4:9399");
                client.DefaultRequestHeaders.Add("Authorization", "Basic VmVlYW1BcGk6QWRkbGluazEyMyE=");
                HttpResponseMessage sessionResponse = client.PostAsync("/api/sessionMngr/?v=v1_3", null).Result;
                XmlDocument sessionResponseDoc = new XmlDocument();
                sessionResponseDoc.LoadXml(sessionResponse.Content.ReadAsStringAsync().Result);
                sessionResponseDoc.DocumentElement.RemoveAllAttributes();
                var s = sessionResponse.Headers.Where(x => x.Key == "X-RestSvcSessionId").FirstOrDefault().Value.First();

                System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                client.DefaultRequestHeaders.Add("X-RestSvcSessionId", s);
                // if()
                try
                {
                    string response = client.GetStringAsync("/api/cloud/tenants/" + UID + "?format=Entity").Result;
                    XmlSerializer serializer = new XmlSerializer(typeof(CloudTenant));

                    using (TextReader reader = new StringReader(response))
                    {
                        data = (CloudTenant)serializer.Deserialize(reader);
                    }
                    return data;
                }
                catch (Exception e)
                {
                    var resule = e.Message;
                    var resule2 = e.Data;
                    var resule3 = e.Source;
                    var resule4 = e.HResult;
                }


            }
            return new CloudTenant();
        }
        public StringContent ConvertObjectToXmlString(CloudTenant tenantObj)
        {
            string xml;

            XmlSerializer xs = new XmlSerializer(typeof(CloudTenant));
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xs.Serialize(writer, tenantObj);
                    xml = Regex.Replace(sw.ToString(), "utf-16", "utf-8", RegexOptions.IgnoreCase);
                }
            }

            return new StringContent(xml, Encoding.UTF8, "application/xml");
        }
        public static string ConvertXml2Json(string XmlElements)
        {
            string lines = Regex.Replace(XmlElements, "@", "", RegexOptions.Singleline);
            var xml = new XmlDocument();
            xml.LoadXml(lines);
            var jsonText = JsonConvert.SerializeXmlNode(xml, Newtonsoft.Json.Formatting.Indented);
            var json = Regex.Replace(jsonText, "(?<=\")(@)(?!.*\":\\s )", string.Empty, RegexOptions.IgnoreCase);
            return json;
        }
        public object putEditTenant(string UID, HttpContent content = null)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.50.18.4:9399");
                client.DefaultRequestHeaders.Add("Authorization", "Basic VmVlYW1BcGk6QWRkbGluazEyMyE=");
                HttpResponseMessage sessionResponse = client.PostAsync("/api/sessionMngr/?v=v1_3", null).Result;
                XmlDocument sessionResponseDoc = new XmlDocument();
                sessionResponseDoc.LoadXml(sessionResponse.Content.ReadAsStringAsync().Result);
                sessionResponseDoc.DocumentElement.RemoveAllAttributes();
                var s = sessionResponse.Headers.Where(x => x.Key == "X-RestSvcSessionId").FirstOrDefault().Value.First();

                System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                client.DefaultRequestHeaders.Add("X-RestSvcSessionId", s);
                var a = client.PutAsync("/api/cloud/tenants/" + UID, content).Result;
                return a;
            }
        }

        //////////////////////////////////////////// Upgrade Replication ///////////////////////////////////////////////
        public CloudHardwarePlan Get_HardwarePlanByID(HttpClient connect, string HardwarePlanID)
        {
            CloudHardwarePlan data;
            string response = connect.GetStringAsync("/api/cloud/hardwarePlans/" + HardwarePlanID + "?format=Entity").Result;
            XmlSerializer serializer = new XmlSerializer(typeof(CloudHardwarePlan));
            using (TextReader reader = new StringReader(response))
            {
                data = (CloudHardwarePlan)serializer.Deserialize(reader);
            }
            return data;
        }
        public HttpClient ConnectVCC_API()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://10.50.18.4:9399");
            client.DefaultRequestHeaders.Add("Authorization", "Basic VmVlYW1BcGk6QWRkbGluazEyMyE=");
            HttpResponseMessage sessionResponse = client.PostAsync("/api/sessionMngr/?v=v1_3", null).Result;
            XmlDocument sessionResponseDoc = new XmlDocument();
            sessionResponseDoc.LoadXml(sessionResponse.Content.ReadAsStringAsync().Result);
            sessionResponseDoc.DocumentElement.RemoveAllAttributes();
            var ss = sessionResponse.Headers.Where(x => x.Key == "X-RestSvcSessionId").FirstOrDefault().Value.First();

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", ss);
            return client;
        }
        public string Get_UIDbyHardwareName(HttpClient connect, string name)
        {
            var res = connect.GetAsync("/api/query?type=CloudHardwarePlan&filter=Name==HW" + name).Result;
            var con = res.Content.ReadAsStringAsync().Result;

            XmlDocument s = new XmlDocument();
            s.LoadXml(con);
            string uid = s.GetElementsByTagName("Ref")[0].Attributes[0].InnerText;
            return uid;
        }
        public StringContent Cv_CloudHardwarePlanToXmlStr(CloudHardwarePlan obj)
        {
            string xml;
            XmlSerializer xs = new XmlSerializer(typeof(CloudHardwarePlan));
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xs.Serialize(writer, obj);
                    xml = Regex.Replace(sw.ToString(), "utf-16", "utf-8", RegexOptions.IgnoreCase);
                }
            }
            return new StringContent(xml, Encoding.UTF8, "application/xml");
        }
        public string Put_EditHardwarePlan(HttpClient connect, HttpContent content, string HardwarePlanID)
        {
            var res = connect.PutAsync("/api/cloud/hardwarePlans/" + HardwarePlanID, content).Result;
            var con = res.Content.ReadAsStringAsync().Result;
            return con;
        }
        public string Delete_Tenant(HttpClient connect, string UID)
        {
            var res = connect.DeleteAsync("/api/cloud/tenants/" + UID).Result;
            var con = res.Content.ReadAsStringAsync().Result;
            return con;
        }
        #endregion

        #region calculate invoice non-save in database
        public v_Get_InvoviceById_package_backup TryGanerateInvoiceForVeeamBackUp(int pck_id, int vm, int stor, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<v_Get_InvoviceById_package_backup>("EXEC [backup].[s_invoice_try_calculate_veeam_backup] @pck_id, @vm, @storage, @premiums_storage",
              new SqlParameter("@pck_id ", pck_id),
              new SqlParameter("@vm", vm),
              new SqlParameter("@storage", stor),
              new SqlParameter("@premiums_storage", premiums_storage)
            ).FirstOrDefault();
            return res;
        }

        public v_Get_InvoviceById_package_replication TryGanerateInvoiceForVeeamReplication(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<v_Get_InvoviceById_package_replication>("EXEC [backup].[s_invoice_try_calculate_veeam_replication] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
                 new SqlParameter("@pck_id", pck_id),
                 new SqlParameter("@vm", vm),
                 new SqlParameter("@storage", storage),
                 new SqlParameter("@processor", processor),
                 new SqlParameter("@ram", ram),
                 new SqlParameter("@ip_address", ip_address),
                 new SqlParameter("@networks", networks),
                 new SqlParameter("@traffic", traffic),
                 new SqlParameter("@premiums_storage", premiums_storage)
             ).FirstOrDefault();
            return res;
        }
        public v_Get_InvoviceById_package_backup_resaller TryGanerateInvoiceForVeeamBackUpResaller(int pck_id, int vm, int stor, bool premiums_storage)
        {
                var res = db.Database.SqlQuery<v_Get_InvoviceById_package_backup_resaller>("EXEC [backup].[s_invoice_try_calculate_veeam_backup_resaller] @pck_id, @vm, @storage, @premiums_storage",
                  new SqlParameter("@pck_id ", pck_id),
                  new SqlParameter("@vm", vm),
                  new SqlParameter("@storage", stor),
                  new SqlParameter("@premiums_storage", premiums_storage)
                ).FirstOrDefault();
            return res;
        }

        public v_Get_InvoviceById_package_replication_resaller TryGanerateInvoiceForVeeamReplicationResaller(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<v_Get_InvoviceById_package_replication_resaller>("EXEC [backup].[s_invoice_try_calculate_veeam_replication_resaller] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
                   new SqlParameter("@pck_id", pck_id),
                   new SqlParameter("@vm", vm),
                   new SqlParameter("@storage", storage),
                   new SqlParameter("@processor", processor),
                   new SqlParameter("@ram", ram),
                   new SqlParameter("@ip_address", ip_address),
                   new SqlParameter("@networks", networks),
                   new SqlParameter("@traffic", traffic),
                   new SqlParameter("@premiums_storage", premiums_storage)
               ).FirstOrDefault();
            return res;
        }
        #endregion

        #region calculate invoice save in database
        public Packages2 SaveGanerateInvoiceForVeeamBackUp(int pck_id, int stor, int vm, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_invoice_save_calculate_veeam_backup] @pck_id, @vm, @storage, @premiums_storage",
                  new SqlParameter("@pck_id ", pck_id),
                  new SqlParameter("@vm", vm),
                  new SqlParameter("@storage", stor),
                  new SqlParameter("@premiums_storage", premiums_storage)

                ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }

        public Packages2 SaveGanerateInvoiceForVeeamReplication(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_invoice_save_calculate_veeam_replication] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
              new SqlParameter("@pck_id", pck_id),
              new SqlParameter("@vm", vm),
              new SqlParameter("@storage", storage),
              new SqlParameter("@processor", processor),
              new SqlParameter("@ram", ram),
              new SqlParameter("@ip_address", ip_address),
              new SqlParameter("@networks", networks),
              new SqlParameter("@traffic", traffic),
              new SqlParameter("@premiums_storage", premiums_storage)
          ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }
        public Packages2 SaveGanerateInvoiceForVeeamBackUpResaller(int pck_id, int stor, int vm, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_invoice_save_calculate_veeam_backup_resaller] @pck_id, @vm, @storage, @premiums_storage",
                   new SqlParameter("@pck_id ", pck_id),
                   new SqlParameter("@vm", vm),
                   new SqlParameter("@storage", stor),
                   new SqlParameter("@premiums_storage", premiums_storage)

                 ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }

        public Packages2 SaveGanerateInvoiceForVeeamReplicationResaller(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_invoice_save_calculate_veeam_replication_resaller] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
                    new SqlParameter("@pck_id", pck_id),
                    new SqlParameter("@vm", vm),
                    new SqlParameter("@storage", storage),
                    new SqlParameter("@processor", processor),
                    new SqlParameter("@ram", ram),
                    new SqlParameter("@ip_address", ip_address),
                    new SqlParameter("@networks", networks),
                    new SqlParameter("@traffic", traffic),
                    new SqlParameter("@premiums_storage", premiums_storage)
                ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }
        #endregion

        #region request upgrade package for enterprise
        public Packages2 RequestSaveGanerateInvoiceForVeeamBackUpEnterprise(int pck_id, int stor, int vm, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_invoice_requst_calculate_veeam_backup] @pck_id, @vm, @storage, @premiums_storage",
                new SqlParameter("@pck_id ", pck_id),
                new SqlParameter("@vm", vm),
                new SqlParameter("@storage", stor),
                new SqlParameter("@premiums_storage", premiums_storage)

              ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }

        public Packages2 RequestSaveGanerateInvoiceForVeeamReplicationEnterprise(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_invoice_requst_calculate_veeam_replication] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
             new SqlParameter("@pck_id", pck_id),
             new SqlParameter("@vm", vm),
             new SqlParameter("@storage", storage),
             new SqlParameter("@processor", processor),
             new SqlParameter("@ram", ram),
             new SqlParameter("@ip_address", ip_address),
             new SqlParameter("@networks", networks),
             new SqlParameter("@traffic", traffic),
             new SqlParameter("@premiums_storage", premiums_storage)
         ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }
        #endregion

        #region request enterprise upgrade package in veeam tenant

        public bool UpdatePackageVeeamBackUpEnterprise(int pck_id, int vm, uint storage)
        {
            UpgradePackage veeam = new UpgradePackage();
            var changePackage_status = db.Packages2.Where(x => x.pck_id == pck_id).FirstOrDefault();
            var invostatus = db.Cart.Where(c => c.cart_id == changePackage_status.cart_id).FirstOrDefault();
            var findVcc_id = db.Veeam_Tenant.FirstOrDefault(v => v.pck_id == changePackage_status.pck_id_ref);
            var Tenant = veeam.getCloudTenantsByUID(findVcc_id.tenant_id.ToString());
            System.Threading.Thread.Sleep(4000);
            Tenant.Resources.CloudTenantResource.RepositoryQuota.Quota = Tenant.Resources.CloudTenantResource.RepositoryQuota.Quota + (storage * 1024);
            var xmlScript = veeam.ConvertObjectToXmlString(Tenant);
            System.Threading.Thread.Sleep(4000);
            var s = veeam.putEditTenant(findVcc_id.tenant_id.ToString(), xmlScript);

            changePackage_status.pck_status = "et";
            invostatus.status = "et";
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public bool UpdatePackageVeeamReplicationEnterprise(int pck_id, int storage, int processor, int memory, int networks)
        {
            UpgradePackage veeam = new UpgradePackage();
            var changePackage_status = db.Packages2.Where(x => x.pck_id == pck_id).FirstOrDefault();
            var invostatus = db.Cart.Where(c => c.cart_id == changePackage_status.cart_id).FirstOrDefault();
            changePackage_status.pck_status = "et";
            invostatus.status = "et";
            int res = db.SaveChanges();
            var connection = veeam.ConnectVCC_API();
            var findVcc_id = db.Veeam_Tenant.FirstOrDefault(v => v.pck_id == changePackage_status.pck_id_ref);
            var HWUID = veeam.Get_UIDbyHardwareName(connection, findVcc_id.vcc_id.ToString());
            if (HWUID != null)
            {
                var hw = veeam.Get_HardwarePlanByID(connection, HWUID.Replace("urn:veeam:CloudHardwarePlan:", ""));
                System.Threading.Thread.Sleep(4000);
                hw.ProcessorUsageLimitMhz += (ushort)(processor * 1024);
                hw.MemoryUsageLimitMb += (ushort)(memory * 1024);
                hw.HardwarePlanDetails.ViCloudHardwarePlan.Datastores.Datastore.QuotaGb += (ushort)storage;
                hw.HardwarePlanDetails.ViCloudHardwarePlan.Network.CountWithoutInternet += (byte)networks;
                var stringContent = veeam.Cv_CloudHardwarePlanToXmlStr(hw);
                var editResponse = veeam.Put_EditHardwarePlan(connection, stringContent, HWUID.Replace("urn:veeam:CloudHardwarePlan:", ""));
                return res > 0? true:false;
            }
            return false;
        }
        #endregion

        #region upgrade package in veeam tenant
        public bool UpdatePackageVeeamBackUp(int pck_id, int vm, uint storage)
        {
            UpgradePackage veeam = new UpgradePackage();
            var changePackage_status = db.Packages2.FirstOrDefault(x => x.pck_id == pck_id);
            var findVcc_id = db.Veeam_Tenant.FirstOrDefault(v => v.pck_id == changePackage_status.pck_id_ref);
            var Tenant = veeam.getCloudTenantsByUID(findVcc_id.tenant_id.ToString());
            System.Threading.Thread.Sleep(4000);
            Tenant.Resources.CloudTenantResource.RepositoryQuota.Quota = Tenant.Resources.CloudTenantResource.RepositoryQuota.Quota + (storage * 1024);
            var xmlScript = veeam.ConvertObjectToXmlString(Tenant);
            System.Threading.Thread.Sleep(4000);
            var s = veeam.putEditTenant(findVcc_id.tenant_id.ToString(), xmlScript);
            return true;
        }


        public bool UpdatePackageVeeamReplition(int pck_id, int storage, int processor, int memory, int networks)
         {
            UpgradePackage veeam = new UpgradePackage();
            var changePackage_status = db.Packages2.FirstOrDefault(x => x.pck_id == pck_id);
            var connection = veeam.ConnectVCC_API();
            var changeCart_status = db.Cart.FirstOrDefault(c => c.cart_id == changePackage_status.cart_id);
            var findVcc_id = db.Veeam_Tenant.FirstOrDefault(v => v.pck_id == changePackage_status.pck_id_ref);
            var HWUID = veeam.Get_UIDbyHardwareName(connection, findVcc_id.vcc_id.ToString());
            if (HWUID != null)
            {
                var hw = veeam.Get_HardwarePlanByID(connection, HWUID.Replace("urn:veeam:CloudHardwarePlan:", ""));
                System.Threading.Thread.Sleep(4000);
                hw.ProcessorUsageLimitMhz += (ushort)(processor * 1024);
                hw.MemoryUsageLimitMb += (ushort)(memory * 1024);
                hw.HardwarePlanDetails.ViCloudHardwarePlan.Datastores.Datastore.QuotaGb += (ushort)storage;
                hw.HardwarePlanDetails.ViCloudHardwarePlan.Network.CountWithoutInternet += (byte)networks;
                var stringContent = veeam.Cv_CloudHardwarePlanToXmlStr(hw);
                var editResponse = veeam.Put_EditHardwarePlan(connection, stringContent, HWUID.Replace("urn:veeam:CloudHardwarePlan:", ""));
                return true;
            }
            return false;
        }
        #endregion

        #region get invoice by id package

        public v_Get_InvoviceById_package_backup Get_Invoice_ById_PackageBackUp(int pck_id)
        {
            return db.v_Get_InvoviceById_package_backup.Where(c => c.temp_pck_id == pck_id).FirstOrDefault();
        }

        public v_Get_InvoviceById_package_replication Get_Invoice_ById_PackageReplication(int pck_id)
        {
            return db.v_Get_InvoviceById_package_replication.Where(c => c.temp_pck_id == pck_id).FirstOrDefault();
        }

        public v_Get_InvoviceById_package_backup_resaller Get_Invoice_ById_PackageBackUpResaller(int pck_id)
        {
            return db.v_Get_InvoviceById_package_backup_resaller.Where(c => c.temp_pck_id == pck_id).FirstOrDefault();
        }

        public v_Get_InvoviceById_package_replication_resaller Get_Invoice_ById_PackageReplicationResaller(int pck_id)
        {
            return db.v_Get_InvoviceById_package_replication_resaller.Where(c => c.temp_pck_id == pck_id).FirstOrDefault();
        }

        public v_Get_InvoviceById_package_backup_Nakivo Get_Invoice_ById_PackageBackUp_Nakivo(int pck_id)
        {
            return db.v_Get_InvoviceById_package_backup_Nakivo.Where(c => c.temp_pck_id == pck_id).FirstOrDefault();
        }

        public v_Get_InvoviceById_package_backup_Nakivo_resaller Get_Invoice_ById_PackageBackUpResaller_Nakivo(int pck_id)
        {
            return db.v_Get_InvoviceById_package_backup_Nakivo_resaller.Where(c => c.temp_pck_id == pck_id).FirstOrDefault();
        }
        #endregion

        #region upgrade in prolong
        public Packages2 ProlongUpgradeForVeeamBackUpEnterprise(int pck_id, int stor, int vm, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_Upgrade_in_prolong_veeam_backup_enterprise] @pck_id, @vm, @storage, @premiums_storage",
                 new SqlParameter("@pck_id ", pck_id),
                 new SqlParameter("@vm", vm),
                 new SqlParameter("@storage", stor),
                 new SqlParameter("@premiums_storage", premiums_storage)

               ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }

        public Packages2 ProlongUpgradeForVeeamReplicationEnterprise(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_Upgrade_in_prolong_veeam_replication_enterprise] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
                  new SqlParameter("@pck_id", pck_id),
                  new SqlParameter("@vm", vm),
                  new SqlParameter("@storage", storage),
                  new SqlParameter("@processor", processor),
                  new SqlParameter("@ram", ram),
                  new SqlParameter("@ip_address", ip_address),
                  new SqlParameter("@networks", networks),
                  new SqlParameter("@traffic", traffic),
                  new SqlParameter("@premiums_storage", premiums_storage)
                ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }

        public Packages2 ProlongUpgradeForVeeamBackUpResaller(int pck_id, int stor, int vm, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_Upgrade_in_prolong_veeam_backup_resaller] @pck_id, @vm, @storage, @premiums_storage",
                 new SqlParameter("@pck_id ", pck_id),
                 new SqlParameter("@vm", vm),
                 new SqlParameter("@storage", stor),
                 new SqlParameter("@premiums_storage", premiums_storage)

               ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }

        public Packages2 ProlongUpgradeForVeeamReplicationResaller(int pck_id, int vm, int storage, int processor, int ram, int ip_address, int networks, int traffic, bool premiums_storage)
        {
            var res = db.Database.SqlQuery<Packages2>("EXEC [backup].[s_Upgrade_in_prolong_veeam_replication_resaller] @pck_id,@vm, @storage,@processor,@ram,@ip_address,@networks,@traffic,@premiums_storage",
              new SqlParameter("@pck_id", pck_id),
              new SqlParameter("@vm", vm),
              new SqlParameter("@storage", storage),
              new SqlParameter("@processor", processor),
              new SqlParameter("@ram", ram),
              new SqlParameter("@ip_address", ip_address),
              new SqlParameter("@networks", networks),
              new SqlParameter("@traffic", traffic),
              new SqlParameter("@premiums_storage", premiums_storage)
            ).FirstOrDefault();
            System.Threading.Thread.Sleep(2000);
            return res;
        }
        #endregion
        public Veeam_Tenant Get_Veeam_Tenant_ById_PackageBackUp(int pck_id)
        {
            var findpck_ref = db.Packages2.Where(c => c.pck_id == pck_id).FirstOrDefault();
            return db.Veeam_Tenant.Where(c => c.pck_id == findpck_ref.pck_id_ref).FirstOrDefault();
        }
        #region interface get invoice by id Invoice
        public v_Get_InvoviceById_package_backup Get_Invoice_ById_InvoiceBackUp(int invoice_no)
        {
            return db.v_Get_InvoviceById_package_backup.Where(c => c.Invoice_no.Equals(invoice_no)).FirstOrDefault();
        }

        public v_Get_InvoviceById_package_replication Get_Invoice_ById_InvoiceReplication(int invoice_no)
        {
            return db.v_Get_InvoviceById_package_replication.Where(c => c.Invoice_no.Equals(invoice_no)).FirstOrDefault();
        }

        public v_Get_InvoviceById_package_backup_resaller Get_Invoice_ById_InvoiceBackUpResaller(int invoice_no)
        {
            return db.v_Get_InvoviceById_package_backup_resaller.Where(c => c.Invoice_no.Equals(invoice_no)).FirstOrDefault();
        }

        public v_Get_InvoviceById_package_replication_resaller Get_Invoice_ById_InvoiceReplicationResaller(int invoice_no)
        {
            return db.v_Get_InvoviceById_package_replication_resaller.Where(c => c.Invoice_no.Equals(invoice_no)).FirstOrDefault();
        }
        public v_Get_InvoviceById_package_backup_Nakivo Get_Invoice_ById_InvoiceBackUp_Nakivo(int invoice_no)
        {
            return db.v_Get_InvoviceById_package_backup_Nakivo.Where(c => c.Invoice_no.Equals(invoice_no)).FirstOrDefault();
        }
        public v_Get_InvoviceById_package_backup_Nakivo_resaller Get_Invoice_ById_InvoiceBackUpResaller_Nakivo(int invoice_no)
        {
            return db.v_Get_InvoviceById_package_backup_Nakivo_resaller.Where(c => c.Invoice_no.Equals(invoice_no)).FirstOrDefault();
        }
        #endregion
    }
}


