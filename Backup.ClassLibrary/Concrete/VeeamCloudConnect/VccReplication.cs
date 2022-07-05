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
    public class VccReplication
    {
        private const string Host = "http://10.50.18.4:9399";
        private const string Auth = "Basic VmVlYW1BcGk6QWRkbGluazEyMyE=";
        private const string Repository_QNAP = "d97741ab-133d-4845-a90f-e2bd7e72d2f1";
        private const string Repository_HP = "e9ab90ad-fb6c-43f8-8693-16c4bdab94d1";
        private const string BackupServer = "d9a883f4-0e2d-45d7-8ee8-cdd0eeb58fa1";
        private const string VMwareHost = "2495fb95-df31-44ba-937d-0244441a1d20.ha-host";
        private const string VMwareDatastore = "0d26efeb-e117-4b68-a1c0-846653d57821.599fa2a3-bc50beea-406b-70106fc6b1bc";

        public HttpClient ConnectVCC_API()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            var client = new HttpClient();

            client.BaseAddress = new Uri(Host);
            client.DefaultRequestHeaders.Add("Authorization", Auth);
            HttpResponseMessage sessionResponse = client.PostAsync("/api/sessionMngr/?v=v1_3", null).Result;
            XmlDocument sessionResponseDoc = new XmlDocument();
            sessionResponseDoc.LoadXml(sessionResponse.Content.ReadAsStringAsync().Result);
            sessionResponseDoc.DocumentElement.RemoveAllAttributes();
            var ss = sessionResponse.Headers.Where(x => x.Key == "X-RestSvcSessionId").FirstOrDefault().Value.First();

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", ss);
            return client;

        }

        //public bool CreateTenantReplication(string username, string password, DateTime expireDate, string BackupServerUid = "", string HardwarePlanUid = "", string Description = "")
        //{
        //    HardwarePlanUid = string.IsNullOrEmpty(HardwarePlanUid) ? this.HardwarePlan().FirstOrDefault().CloudHardwarePlan.UID : HardwarePlanUid;
        //    BackupServerUid = string.IsNullOrEmpty(BackupServerUid) ? BackupServers().FirstOrDefault().BackupServer.UID : BackupServerUid;

        //    string req = @"<?xml version=""1.0"" encoding=""utf-8""?>
        //                <CreateCloudTenantSpec xmlns=""http://www.veeam.com/ent/v1.0"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
        //                 <Name>" + username + @"</Name>
        //                 <Description>Tenant account " + username + @" for " + (!string.IsNullOrEmpty(Description) ? Description : "Awesta Company") + @"</Description> 
        //                 <Password>" + password + @"</Password>
        //                 <Enabled>true</Enabled>
        //                 <LeaseExpirationDate>" + String.Format("{0:s}", expireDate) + @"</LeaseExpirationDate>
        //                 <ComputeResources>
        //                    <ComputeResource>
        //                        <CloudHardwarePlanUid>" + HardwarePlanUid + @"</CloudHardwarePlanUid>
        //                        <PlatformType>VMware</PlatformType>
        //                        <UseNetworkFailoverResources>true</UseNetworkFailoverResources>
        //                    </ComputeResource>
        //                 </ComputeResources>
        //                 <ThrottlingEnabled>false</ThrottlingEnabled>
        //                 <ThrottlingSpeedLimit>1</ThrottlingSpeedLimit>
        //                 <ThrottlingSpeedUnit>MBps</ThrottlingSpeedUnit>
        //                 <PublicIpCount>0</PublicIpCount>
        //                 <BackupServerUid>" + BackupServerUid + @"</BackupServerUid>
        //                 <MaxConcurrentTasks>1</MaxConcurrentTasks>
        //                </CreateCloudTenantSpec>";
        //    try
        //    {

        //        if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
        //        {
        //            X_RestSvcSessionId = getX_RestSvcSessionId();
        //        }

        //        ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
        //        client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);

        //        var contents = new StringContent(req, Encoding.UTF8, "application/xml");

        //        var ResultPost = client.PostAsync(UriApi + "/api/cloud/tenants", contents).Result;

        //        if (ResultPost.StatusCode.Equals(HttpStatusCode.Accepted))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //        return false;
        //    }
        //}

        //public List<CloudHardwarePlans> HardwarePlan()
        //{
        //    if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
        //    {
        //        X_RestSvcSessionId = getX_RestSvcSessionId();
        //    }

        //    System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
        //    client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);

        //    string xmlDocumentText = client.GetStringAsync(UriApi + "/api/cloud/hardwarePlans?format=Entity").Result;

        //    var server = new CloudHardwarePlans();

        //    List<CloudHardwarePlans> listServer = new List<Models.CloudHardwarePlans>();

        //    XmlSerializer serializer = new XmlSerializer(typeof(CloudHardwarePlans));
        //    using (StringReader reader = new StringReader(xmlDocumentText))
        //    {
        //        server = (CloudHardwarePlans)(serializer.Deserialize(reader));
        //        listServer.Add(server);
        //    }

        //    return listServer;


        //}

        public CloudHardwarePlanCreateSpec Set_CloudHardwarePlanCreateSpec(string HW_Name, int ProcessorUsageLimitMhz, int MemoryUsageLimitMb, int QuotaGb, int CountWithoutInternet)
        {
            CloudHardwarePlanCreateSpec obj = new CloudHardwarePlanCreateSpec
            {
                Name = "HW" + HW_Name,
                ProcessorUsageLimitMhz = ProcessorUsageLimitMhz,
                MemoryUsageLimitMb = MemoryUsageLimitMb,
                BackupServerUid = "urn:veeam:BackupServer:" + BackupServer,
                HardwarePlanDetails = new CloudHardwarePlanCreateSpecHardwarePlanDetails
                {
                    ViCloudHardwarePlan = new CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlan
                    {
                        HypervisorHostRef = "urn:VMware:Host:" + VMwareHost,
                        ParentType = "HostSystem",
                        ParentName = "esx01.tech.local",
                        Datastores = new CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanDatastores
                        {
                            Datastore = new CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanDatastoresDatastore
                            {
                                FriendlyName = "Cloud Replicas",
                                DatastoreType = "Datastore",
                                Reference = "urn:VMware:Datastore:" + VMwareDatastore,
                                QuotaGb = QuotaGb
                            }
                        },
                        Network = new CloudHardwarePlanCreateSpecHardwarePlanDetailsViCloudHardwarePlanNetwork
                        {
                            CountWithInternet = 0,
                            CountWithoutInternet = CountWithoutInternet
                        }
                    }
                }
            };

            return obj;
        }

        public StringContent Cv_CloudHardwarePlanCreateSpecToXmlStr(CloudHardwarePlanCreateSpec HW_Spec)
        {
            string xml;
            XmlSerializer xs = new XmlSerializer(typeof(CloudHardwarePlanCreateSpec));
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xs.Serialize(writer, HW_Spec);
                    xml = Regex.Replace(sw.ToString(), "utf-16", "utf-8", RegexOptions.IgnoreCase);
                }
            }
            return new StringContent(xml, Encoding.UTF8, "application/xml");
        }

        public string Post_CreateHardwarePlan(HttpClient connect, HttpContent content)
        {
            var res = connect.PostAsync("/api/cloud/hardwarePlans", content).Result;
            var con = res.Content.ReadAsStringAsync().Result;

            XmlDocument s = new XmlDocument();
            s.LoadXml(con);
            try
            {
                string taskId = s.GetElementsByTagName("TaskId")[0].InnerText;
                string state = s.GetElementsByTagName("State")[0].InnerText;
                string operation = s.GetElementsByTagName("Operation")[0].InnerText;
                return taskId;
            }
            catch
            {
                System.Threading.Thread.Sleep(5000);
                res = connect.PostAsync("/api/cloud/hardwarePlans", content).Result;
                con = res.Content.ReadAsStringAsync().Result;
                s.LoadXml(con);
                string taskId = s.GetElementsByTagName("TaskId")[0].InnerText;
                string state = s.GetElementsByTagName("State")[0].InnerText;
                string operation = s.GetElementsByTagName("Operation")[0].InnerText;
                return taskId;
            }
        }
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
        public string Get_UIDbyHardwareName(HttpClient connect, string name)
        {
            var res = connect.GetAsync("/api/query?type=CloudHardwarePlan&filter=Name==HW" + name).Result;
            var con = res.Content.ReadAsStringAsync().Result;

            XmlDocument s = new XmlDocument();
            s.LoadXml(con);
            try
            {
                string uid = s.GetElementsByTagName("Ref")[0].Attributes[0].InnerText;
                return uid;
            }
            catch
            {
                System.Threading.Thread.Sleep(8000);
                res = connect.GetAsync("/api/query?type=CloudHardwarePlan&filter=Name==HW" + name).Result;
                con = res.Content.ReadAsStringAsync().Result;
                s.LoadXml(con);
                string uid = s.GetElementsByTagName("Ref")[0].Attributes[0].InnerText;
                return uid;
            }
        }

        public CreateCloudTenantSpec New_CreateCloudTenantRepSpec(string username, string password, string HWID,int day)
        {
            CreateCloudTenantSpec obj = new CreateCloudTenantSpec
            {
                Name = username,
                Password = password,
                Enabled = true,
                LeaseExpirationDate = DateTime.Now.AddDays(day),
                ComputeResources = new CreateCloudTenantSpecComputeResources
                {
                    ComputeResource = new CreateCloudTenantSpecComputeResourcesComputeResource
                    {
                        CloudHardwarePlanUid = HWID,
                        PlatformType = "VMware",
                        UseNetworkFailoverResources = false
                    }
                },
                ThrottlingEnabled = false,
                ThrottlingSpeedLimit = 1,
                ThrottlingSpeedUnit = "MBps",
                PublicIpCount = 0,
                BackupServerUid = "urn:veeam: BackupServer: " + BackupServer,
                MaxConcurrentTasks = 1,
            };
            return obj;
        }
        public StringContent Cv_CreateCloudTenantSpecToXmlStr(CreateCloudTenantSpec value)
        {
            string xml;
            XmlSerializer xs = new XmlSerializer(typeof(CreateCloudTenantSpec));
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xs.Serialize(writer, value);
                    xml = Regex.Replace(sw.ToString(), "utf-16", "utf-8", RegexOptions.IgnoreCase);
                }
            }
            return new StringContent(xml, Encoding.UTF8, "application/xml");
        }
        public string Post_CreateTenant(HttpClient connect, HttpContent content = null)
        {
            var res = connect.PostAsync("/api/cloud/tenants", content).Result;
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
                System.Threading.Thread.Sleep(5000);
                res = connect.PostAsync("/api/cloud/tenants", content).Result;
                con = res.Content.ReadAsStringAsync().Result;
                doc.LoadXml(con);
                string taskId = doc.GetElementsByTagName("TaskId")[0].InnerText;
                string state = doc.GetElementsByTagName("State")[0].InnerText;
                string operation = doc.GetElementsByTagName("Operation")[0].InnerText;
                return taskId;
            }
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

    }
}
