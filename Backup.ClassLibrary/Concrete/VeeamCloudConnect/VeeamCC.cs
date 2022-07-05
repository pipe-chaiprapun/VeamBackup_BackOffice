using Backup.ClassLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Data;
using Backup.ClassLibrary.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Web.Script.Serialization;

namespace Backup.ClassLibrary.Concrete.VeeamCloudConnect
{
    /// <summary>
    /// Development by farkramdev 01/07/2017
    /// </summary>
    public class VeeamCC : IVeeamCC
    {
        public string TenantName = string.Empty;
        protected string UriApi = string.Empty;
        public string X_RestSvcSessionId = string.Empty;
        public HttpClient client;

        public VeeamCC(string TenantName = "")
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            client = new HttpClient();
            this.TenantName = TenantName;
            this.UriApi = Properties.Settings.Default.VeeamAPI;
        }
        public string Get_UIDByTenantName(HttpClient connect, string TenantName)
        {
            var res = connect.GetAsync("/api/query?type=CloudTenant&filter=Name==" + TenantName).Result;
            var con = res.Content.ReadAsStringAsync().Result;

            XmlDocument s = new XmlDocument();
            s.LoadXml(con);
            try
            {
                string uid = s.GetElementsByTagName("Ref")[0].Attributes[0].InnerText;
                return uid;
            }
            catch (Exception e)
            {
                System.Threading.Thread.Sleep(10000);
                res = connect.GetAsync("/api/query?type=CloudTenant&filter=Name==" + TenantName).Result;
                con = res.Content.ReadAsStringAsync().Result;
                s.LoadXml(con);
                string uid = s.GetElementsByTagName("Ref")[0].Attributes[0].InnerText;
                return uid;
            }
        }
        public StringContent Cv_CloudTenantToXmlStr(CloudTenant obj)
        {
            string xml;
            XmlSerializer xs = new XmlSerializer(typeof(CloudTenant));
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
        public string Put_EditTenant(HttpClient connect, HttpContent content, string UID)
        {
            var res = connect.PutAsync("/api/cloud/tenants/" + UID, content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(con);
            try
            {
                string taskId = doc.GetElementsByTagName("TaskId")[0].InnerText;
                string state = doc.GetElementsByTagName("State")[0].InnerText;
                string operation = doc.GetElementsByTagName("Operation")[0].InnerText;
                return taskId;
            }
            catch
            {
                System.Threading.Thread.Sleep(10000);
                res = connect.PutAsync("/api/cloud/tenants/" + UID, content).Result;
                con = res.Content.ReadAsStringAsync().Result;
                doc.LoadXml(con);
                string taskId = doc.GetElementsByTagName("TaskId")[0].InnerText;
                string state = doc.GetElementsByTagName("State")[0].InnerText;
                string operation = doc.GetElementsByTagName("Operation")[0].InnerText;
                return taskId;
            }
        }
        public CloudTenant Get_TenantByUID(HttpClient connect, string UID)
        {
            CloudTenant data;
            string response = connect.GetStringAsync("/api/cloud/tenants/" + UID + "?format=Entity").Result;
            XmlSerializer serializer = new XmlSerializer(typeof(CloudTenant));
            using (TextReader reader = new StringReader(response))
            {
                data = (CloudTenant)serializer.Deserialize(reader);
            }
            return data;
        }
        public string FindHrefTenantEntity(string TenantName)
        {
            try
            {
                Rootobject Tenants = getCloudTenantsAll();
                return Tenants.EntityReferences.Ref.FirstOrDefault(t => t.Name.Equals(TenantName)).Links.Link[1].Href;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public string getX_RestSvcSessionId()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            string Authorization = Properties.Settings.Default.PassVeeam;
            UriApi = Properties.Settings.Default.VeeamAPI;
            client.DefaultRequestHeaders.Add("Authorization", Authorization);
            var response = client.PostAsync(new Uri(UriApi + "/api/sessionMngr/?v=v1_3"), null).Result;
            response.EnsureSuccessStatusCode();
            X_RestSvcSessionId = response.Headers.GetValues("X-RestSvcSessionId").FirstOrDefault();
            return X_RestSvcSessionId;
        }

        public string ConvertXml2Json(string XmlElements)
        {
            string lines = Regex.Replace(XmlElements, "@", "", RegexOptions.Singleline);
            var xml = new XmlDocument();
            xml.LoadXml(lines);
            var jsonText = JsonConvert.SerializeXmlNode(xml, Newtonsoft.Json.Formatting.Indented);
            var json = Regex.Replace(jsonText, "(?<=\")(@)(?!.*\":\\s )", string.Empty, RegexOptions.IgnoreCase);
            return json;
        }

        public Rootobject getCloudTenantsAll()
        {
            if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
            {
                X_RestSvcSessionId = getX_RestSvcSessionId();
            }

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);
            string responseXml = client.GetStringAsync(UriApi + "/api/cloud/tenants").Result;
            var jsonObjects = ConvertXml2Json(responseXml);
            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(jsonObjects);

            return data;
        }

        public Rootobject getCloudTenantsEntity(string TenantUri)
        {
            if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
            {
                X_RestSvcSessionId = getX_RestSvcSessionId();
            }

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);
            string response = client.GetStringAsync(TenantUri).Result;
            var jsonObjects = ConvertXml2Json(response);
            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(jsonObjects);

            return data;
        }

        public Rootobject getCloudTenantsEntity()
        {

            if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
            {
                X_RestSvcSessionId = getX_RestSvcSessionId();
            }

            Rootobject Tenants = getCloudTenantsAll();

            string TenantUri = Tenants.EntityReferences.Ref.FirstOrDefault(t => t.Name.Equals(TenantName)).Links.Link[1].Href;

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);
            string response = client.GetStringAsync(TenantUri).Result;
            var jsonObjects = ConvertXml2Json(response);
            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(jsonObjects);
            return data;

        }

        public IEnumerable<VeeamReportModel> ReportDetails()
        {
            if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
            {
                X_RestSvcSessionId = getX_RestSvcSessionId();
            }

            string hrefTenant = FindHrefTenantEntity(TenantName);

            if (string.IsNullOrEmpty(hrefTenant))
            {
                VeeamReportModel model = new VeeamReportModel();
                model.TENANT_NAME = "";
                model.QUOTA = "";
                model.FREE_SPACE = "";
                model.USED_SPACE = "";
                model.USED_SPACE_Percent = "";
                model.LAST_RESULT = "";
                model.LAST_ACTIVE = "";
                model.Repository = "";
                model.DESCRIPTION = "";
                model.ThrottlingSpeedLimit = "";
                model.ThrottlingSpeedUnit = "";
                model.BackupCount = "";
                model.ExpirationDate = "";
                List<VeeamReportModel> items = new List<VeeamReportModel>();
                items.Clear();
                items.Add(model);

                return items.ToList();
            }
            else
            {
                Rootobject tanant = getCloudTenantsEntity(hrefTenant);

                decimal Quota = (!string.IsNullOrEmpty(tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.Quota)) ? decimal.Parse(tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.Quota) : 0;
                decimal UsedQuota = (!string.IsNullOrEmpty(tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.UsedQuota)) ? decimal.Parse(tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.UsedQuota) : 0;
                string QUOTA = (Math.Ceiling((Quota)) >= 1024 ? (Math.Ceiling((Quota)) / 1024).ToString("F") + "GB" : Math.Ceiling((Quota)).ToString("F") + "MB").ToString();
                string FREESPACE = (Math.Ceiling((Quota)) >= 1024 ? ((Math.Ceiling(Quota) - Math.Ceiling(UsedQuota)) / 1024).ToString("F") + "GB" : (Math.Ceiling(Quota) - Math.Ceiling(UsedQuota)).ToString("F") + "MB");
                string USEDSPACE = (Math.Ceiling((UsedQuota)) >= 1024 ? (Math.Ceiling((UsedQuota)) / 1024).ToString("F") + "GB" : Math.Ceiling((UsedQuota)).ToString("F") + "MB").ToString();
                string USEDSPACEP = ((UsedQuota / Quota) * 100).ToString("N0") + "%";

                VeeamReportModel model = new VeeamReportModel();
                model.TENANT_NAME = tanant.CloudTenant.Name;
                model.QUOTA = QUOTA;
                model.FREE_SPACE = FREESPACE;
                model.USED_SPACE = USEDSPACE;
                model.USED_SPACE_Percent = USEDSPACEP;
                model.LAST_RESULT = tanant.CloudTenant.LastResult;
                model.LAST_ACTIVE = tanant.CloudTenant.LastActive.ToString();
                model.Repository = tanant.CloudTenant.Resources.CloudTenantResource.RepositoryQuota.DisplayName;
                model.DESCRIPTION = tanant.CloudTenant.Description;
                model.ThrottlingSpeedLimit = tanant.CloudTenant.ThrottlingSpeedLimit;
                model.ThrottlingSpeedUnit = tanant.CloudTenant.ThrottlingSpeedUnit;
                model.BackupCount = tanant.CloudTenant.BackupCount;
                model.ExpirationDate = tanant.CloudTenant.LeaseOptions.ToString();
                List<VeeamReportModel> items = new List<VeeamReportModel>();
                items.Clear();
                items.Add(model);

                return items.ToList();
            }
        }

        public Rootobject getRepositories()
        {
            if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
            {
                X_RestSvcSessionId = getX_RestSvcSessionId();
            }

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);
            string responseXml = client.GetStringAsync(UriApi + "/api/repositories?format=Entity").Result;
            var jsonObjects = ConvertXml2Json(responseXml);
            var data = JsonConvert.DeserializeObject<Rootobject>(jsonObjects);

            return data;
        }

        public List<BackupServers> BackupServers()
        {
            if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
            {
                X_RestSvcSessionId = getX_RestSvcSessionId();
            }

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);

            string xmlDocumentText = client.GetStringAsync(UriApi + "/api/backupServers?format=Entity").Result;

            var server = new BackupServers();

            List<BackupServers> listServer = new List<Models.BackupServers>();

            XmlSerializer serializer = new XmlSerializer(typeof(BackupServers));
            using (StringReader reader = new StringReader(xmlDocumentText))
            {
                server = (BackupServers)(serializer.Deserialize(reader));
                listServer.Add(server);
            }

            return listServer;
        }

        public List<Backup.ClassLibrary.Models.Veeam.Repositories> Repositorys()
        {
            if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
            {
                X_RestSvcSessionId = getX_RestSvcSessionId();
            }
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);
            string xmlDocumentText = client.GetStringAsync(UriApi + "/api/repositories?format=Entity").Result;
            var Repositorie = new Backup.ClassLibrary.Models.Veeam.Repositories();
            List<Backup.ClassLibrary.Models.Veeam.Repositories> listRepositories = new List<Backup.ClassLibrary.Models.Veeam.Repositories>();
            XmlSerializer serializer = new XmlSerializer(typeof(Backup.ClassLibrary.Models.Veeam.Repositories));
            using (StringReader reader = new StringReader(xmlDocumentText))
            {
                Repositorie = (Backup.ClassLibrary.Models.Veeam.Repositories)(serializer.Deserialize(reader));
                listRepositories.Add(Repositorie);
            }
            return listRepositories;
        }

        public string getUIDTenantByTenantName(string TenantName)
        {
            Rootobject Tenants = new Rootobject();
            Tenants = getCloudTenantsAll();

            var EntityObj = Tenants.EntityReferences.Ref.Where(x => x.Name.Equals(TenantName)).FirstOrDefault();

            Thread.Sleep(5000);

            if (EntityObj == null)
            {
                Tenants = this.getCloudTenantsAll();
                EntityObj = Tenants.EntityReferences.Ref.Where(x => x.Name.Equals(TenantName)).FirstOrDefault();
            }

            string UID = EntityObj.UID;

            return Regex.Replace(UID, "urn:veeam:CloudTenant:", string.Empty, RegexOptions.IgnoreCase);
        }

        public bool CreateTenant(string username, string password, DateTime expireDate, int Quota, string BackupServerUid = "", string RepositoryUid = "", string Description = "")
        {
            BackupServerUid = string.IsNullOrEmpty(BackupServerUid) ? BackupServers().FirstOrDefault().BackupServer.UID : BackupServerUid;
            RepositoryUid = string.IsNullOrEmpty(RepositoryUid) ? this.Repositorys().FirstOrDefault().Repository.UID : RepositoryUid;

            int QuotaMb = Quota * 1024;
            string req = @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <CreateCloudTenantSpec xmlns=""http://www.veeam.com/ent/v1.0"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                         <Name>" + username + @"</Name>
                         <Description>Tenant account " + username + @" for " + (!string.IsNullOrEmpty(Description) ? Description : "Awesta Company") + @"</Description> 
                         <Password>" + password + @"</Password>
                         <Enabled>true</Enabled>
                         <LeaseExpirationDate>" + String.Format("{0:s}", expireDate) + @"</LeaseExpirationDate>
                         <Resources>
                           <BackupResource>
                             <Name>" + username + @" Repository</Name>
                             <RepositoryUid>" + RepositoryUid + @"</RepositoryUid>
                             <QuotaMb>" + QuotaMb + @"</QuotaMb>
                           </BackupResource>
                         </Resources>
                         <ThrottlingEnabled>false</ThrottlingEnabled>
                         <ThrottlingSpeedLimit>1</ThrottlingSpeedLimit>
                         <ThrottlingSpeedUnit>MBps</ThrottlingSpeedUnit>
                         <PublicIpCount>0</PublicIpCount>
                         <BackupServerUid>" + BackupServerUid + @"</BackupServerUid>
                         <MaxConcurrentTasks>1</MaxConcurrentTasks>
                        </CreateCloudTenantSpec>";
            try
            {
                if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
                {
                    X_RestSvcSessionId = getX_RestSvcSessionId();
                }

                System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);

                var contents = new StringContent(req, Encoding.UTF8, "application/xml");
                var ResultPost = client.PostAsync(UriApi + "/api/cloud/tenants", contents).Result;

                if (ResultPost.StatusCode.Equals(HttpStatusCode.Accepted))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        /////////////////////////////////////////////////////// Failover //////////////////////////////////////////////////////
        public HttpClient ConnectVCC_API()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            var client = new HttpClient();

            client.BaseAddress = new Uri(UriApi);
            client.DefaultRequestHeaders.Add("Authorization", Properties.Settings.Default.PassVeeam);
            HttpResponseMessage sessionResponse = client.PostAsync("/api/sessionMngr/?v=v1_3", null).Result;
            XmlDocument sessionResponseDoc = new XmlDocument();
            sessionResponseDoc.LoadXml(sessionResponse.Content.ReadAsStringAsync().Result);
            sessionResponseDoc.DocumentElement.RemoveAllAttributes();
            var ss = sessionResponse.Headers.Where(x => x.Key == "X-RestSvcSessionId").FirstOrDefault().Value.First();

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", ss);
            return client;

        }
        public object GetFailoverPlan(HttpClient connection, string VCC)
        {
            CloudFailoverPlans data;
            var res = connection.GetStringAsync("/api/cloud/cloudFailoverPlans?format=Entity").Result;
            XmlSerializer serializer = new XmlSerializer(typeof(CloudFailoverPlans));
            using (TextReader reader = new StringReader(res))
            {
                data = (CloudFailoverPlans)serializer.Deserialize(reader);
            }
            return data;
        }

        /// <summary>
        /// Use for Enable or Disable Tenant of Veeam API
        /// </summary>
        /// <param name="Uid">Tenant Uid</param>
        /// <param name="veeam_username">Tenant veeam username</param>
        /// <param name="state">boolean status tenant</param>
        /// <returns></returns>
        public bool DisableEnableTenant(string Uid, string veeam_username, bool state)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(UriApi + "/api/cloud/tenants/" + Uid);
            string ReqAPI = sb.ToString();            

            sb.Clear();

            sb.Append("<CloudTenant Type=\"CloudTenant\" Href=\"" + ReqAPI + "?format=Entity\" Name=\"" + veeam_username + "\" UID=\"urn:veeam:CloudTenant:" + Uid + "\" xmlns=\"http://www.veeam.com/ent/v1.0\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
            sb.Append("<Enabled>"+state.ToString().ToLower()+"</Enabled>");
            sb.Append("</CloudTenant>");

            try
            {
                if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
                {
                    X_RestSvcSessionId = getX_RestSvcSessionId();
                }

                System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);

                string req = sb.ToString();
                var contents = new StringContent(req, Encoding.UTF8, "application/xml");
                var ResultPost = client.PutAsync(ReqAPI, contents).Result;
                var content_resp = ResultPost.Content.ReadAsStringAsync().Result;
                Thread.Sleep(2000);
                var data = new Backup.ClassLibrary.Models.Task();

                XmlSerializer serializer = new XmlSerializer(typeof(Backup.ClassLibrary.Models.Task));
                using (StringReader reader = new StringReader(content_resp))
                {
                    data = (Backup.ClassLibrary.Models.Task)(serializer.Deserialize(reader));

                    var TaskResult = this.CheckTaskVeeam(data.TaskId).FirstOrDefault();

                    Thread.Sleep(2000);
                    if (TaskResult.Result.Success)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public string SetX_RestSvcSessionId(string X_RestSvcSessionId)
        {
            return this.X_RestSvcSessionId = X_RestSvcSessionId;
        }

        /// <summary>
        /// Check Task about veeam api affter create tenant, etc
        /// </summary>
        /// <param name="TaskId">TaskId of Veeam Schedule Example : task-453</param>
        /// <returns>Task Response from veeam api</returns>
        public IEnumerable<Models.Task> CheckTaskVeeam(string TaskId)
        {
            try
            {
                if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
                {
                    X_RestSvcSessionId = getX_RestSvcSessionId();
                }
                var TaskRespXml = client.GetStringAsync(UriApi + "/api/tasks/" + TaskId).Result;

                XmlSerializer serializer = new XmlSerializer(typeof(Backup.ClassLibrary.Models.Task));
                using (StringReader reader = new StringReader(TaskRespXml))
                {
                    var TaskResult = (Backup.ClassLibrary.Models.Task)(serializer.Deserialize(reader));
                    List<Backup.ClassLibrary.Models.Task> listTask = new List<Backup.ClassLibrary.Models.Task>();
                    listTask.Add(TaskResult);
                    return listTask;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }
    }
}