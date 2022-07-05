using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Backup.ClassLibrary.Concrete
{
    public class VeeamCC2 : IVeeamCC2
    {
        // Test server
        //private const string Host = "http://10.50.41.44:9399";
        //private const string Auth = "Basic QWRtaW5pc3RyYXRvcjpBZGRsaW5rMTIzIQ==";
        //private const string Repository_QNAP = "ddae8a4b-a481-4845-9ed9-8ae48fdbce8f";
        //private const string Repository_HP = "";
        //private const string BackupServer = "88d95175-052d-47fc-9a69-dd56e8c25de4";
        //private const string VMwareHost = "f8fc57fa-d2dd-4494-ae2b-73c8ec25c32a.ha-host";
        //private const string VMwareDatastore = "688b9afb-4346-40a1-bbb0-a266a9ed86f3.59528180-13993d89-c45f-b083fe97b3be";

        //Production Server
        private const string Host = "http://10.50.18.4:9399";
        private const string Host2 = "https://10.50.18.2:4443";
        private const string Auth = "Basic VmVlYW1BcGk6QWRkbGluazEyMyE=";
        private const string Auth2 = @"{'action': 'AuthenticationManagement','method': 'login','data': ['admin', 'Nakivo123!', false],'type': 'rpc','tid': 1}";
        private const string Repository_QNAP = "d97741ab-133d-4845-a90f-e2bd7e72d2f1";
        private const string Repository_HP = "e9ab90ad-fb6c-43f8-8693-16c4bdab94d1";
        private const string BackupServer = "d9a883f4-0e2d-45d7-8ee8-cdd0eeb58fa1";
        private const string VMwareHost = "2495fb95-df31-44ba-937d-0244441a1d20.ha-host";
        private const string VMwareDatastore = "9775ce78-9b45-466b-911f-2be20803f7a1.599fae3e-f62861ef-df26-70106fc6b1bc";


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
        // 1. Create Tenant
        //  1.1 Set Cloud Tenant Spec 
        public CreateCloudTenantSpec Set_CreateCloudTenantSpec(string username, string password, int quote, bool storage = false)
        {
            CreateCloudTenantSpec obj = new CreateCloudTenantSpec
            {
                Name = username,
                Password = password,
                Enabled = true,
                LeaseExpirationDate = DateTime.Now.AddDays(30),

                Resources = new CreateCloudTenantSpecResources
                {
                    BackupResource = new CreateCloudTenantSpecResourcesBackupResource
                    {
                        Name = "Rep_" + username,
                        RepositoryUid = "urn:veeam: Repository:" + (storage == true ? Repository_HP : Repository_QNAP),
                        QuotaMb = quote * 1024
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
        public CreateCloudTenantSpec Set_CreateCloudTenantRepSpec(string username, string password, string HWID)
        {
            CreateCloudTenantSpec obj = new CreateCloudTenantSpec
            {
                Name = username,
                Password = password,
                Enabled = true,
                LeaseExpirationDate = DateTime.Now.AddDays(30),
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
        //  1.2 Convert CreateCloud Teanant Spect Object To XmlString
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
        //  1.3 Post Create Tenant
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

        // 2. Edit tenant
        //  2.1 Get Tenant by UID
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
        public Backup.ClassLibrary.Concrete.VeeamCloudConnect.Replication.CloudTenant Get_TenantRepByUID(string UID)
        {
            Backup.ClassLibrary.Concrete.VeeamCloudConnect.Replication.CloudTenant data;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Host);
                client.DefaultRequestHeaders.Add("Authorization", Auth);
                HttpResponseMessage sessionResponse = client.PostAsync("/api/sessionMngr/?v=v1_3", null).Result;
                XmlDocument sessionResponseDoc = new XmlDocument();
                sessionResponseDoc.LoadXml(sessionResponse.Content.ReadAsStringAsync().Result);
                sessionResponseDoc.DocumentElement.RemoveAllAttributes();
                var s = sessionResponse.Headers.Where(x => x.Key == "X-RestSvcSessionId").FirstOrDefault().Value.First();

                System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                client.DefaultRequestHeaders.Add("X-RestSvcSessionId", s);
                string response = client.GetStringAsync("/api/cloud/tenants/" + UID + "?format=Entity").Result;
                XmlSerializer serializer = new XmlSerializer(typeof(Backup.ClassLibrary.Concrete.VeeamCloudConnect.Replication.CloudTenant));
                using(TextReader reader = new StringReader(response))
                {
                    data = (Backup.ClassLibrary.Concrete.VeeamCloudConnect.Replication.CloudTenant)serializer.Deserialize(reader);
                }
               /* XmlDocument doc = new XmlDocument();
                doc.LoadXml(response);

                data.storage_used = Int32.Parse(doc.GetElementsByTagName("StorageUsageGb")[0].InnerText);
                data.ram_used = Int32.Parse(doc.GetElementsByTagName("MemoryUsageMb")[0].InnerText);
                data.processor_used = Int32.Parse(doc.GetElementsByTagName("CPUCount")[0].InnerText);
                data.replicationCount = Int32.Parse(doc.GetElementsByTagName("ReplicaCount")[0].InnerText);
                data.publicIPCount = Int32.Parse(doc.GetElementsByTagName("PublicIpCount")[0].InnerText);
                data.alias = doc.GetElementsByTagName("""")*/
            }
            return data;
        }

        //  2.2 Convert CloudTenant Object To XmlString
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
        //  2.3 Put Edit Tenant
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

        // 3. Create Hardware Plan
        //  3.1 Set CloudHardwarePlanCreateSpec
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
        //  3.2 Convert CloudHardwarePlanCreateSpec Object To XmlString
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
        //  3.3 Post Create HardwarePlan
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

        // 4. Edti Hardware Plan
        //  4.1 Get HardwarePlan By ID
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
        //  4.2 Convert CloudHardwarePlan Object To XmalString
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
        //  4.3 Put Edit HardwarePlan
        public string Put_EditHardwarePlan(HttpClient connect, HttpContent content, string HardwarePlanID)
        {
            var res = connect.PutAsync("/api/cloud/hardwarePlans/" + HardwarePlanID, content).Result;
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
                res = connect.PutAsync("/api/cloud/hardwarePlans/" + HardwarePlanID, content).Result;
                con = res.Content.ReadAsStringAsync().Result;
                s.LoadXml(con);
                string taskId = s.GetElementsByTagName("TaskId")[0].InnerText;
                string state = s.GetElementsByTagName("State")[0].InnerText;
                string operation = s.GetElementsByTagName("Operation")[0].InnerText;
                return taskId;
            }
        }

        // Filter
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

        public string Filter(HttpClient connect, string QueryType, string filter, string value)
        {
            var res = connect.GetAsync("/api/query?type=" + QueryType + "&filter=" + filter + "==" + value).Result;
            var con = res.Content.ReadAsStringAsync().Result;
            return con;
        }

        public object Delete_Tenant(HttpClient connect, string UID)
        {
            var res = connect.DeleteAsync("/api/cloud/tenants/" + UID).Result;
            return res;
        }

        /////////////////////////////////////////////////// Failover ///////////////////////////////////////////////////
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

        public object GetTaskSessions(HttpClient connection)
        {
            BackupTaskSessions data;
            var resd = connection.GetStringAsync("api/backupTaskSessions?format=Entity").Result;
            XmlSerializer serializer = new XmlSerializer(typeof(BackupTaskSessions));
            using (TextReader reader = new StringReader(resd))
            {
                data = (BackupTaskSessions)serializer.Deserialize(reader);
            }
            return data;
        }

        /*public CloudFailoverPlanManagementSpec SetCloudFailoverStart()
        {
            CloudFailoverPlanManagementSpec obj = new CloudFailoverPlanManagementSpec
            {
                StartNow = true
            };
            return obj;
        }
        public StringContent Cv_CloudFailoverActionToXmlStr(CloudFailoverPlanManagementSpec action)
        {
            string xml;
            XmlSerializer xs = new XmlSerializer(typeof(CloudFailoverPlanManagementSpec));
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xs.Serialize(writer, action);
                    xml = Regex.Replace(sw.ToString(), "utf-16", "utf-8", RegexOptions.IgnoreCase);
                }
            }
            return new StringContent(xml, Encoding.UTF8, "application/xml");
        }*/
        public string Post_CloudFailoverStart(HttpClient connect, HttpContent content, string UID)
        {
            var res = connect.PostAsync("/api/cloud/cloudFailoverPlans/" + UID.Replace("urn:veeam:CloudFailoverPlan:", "") + "?action=start", content).Result;
            var con = res.Content.ReadAsStringAsync().Result;
            return con;
        }
        public string Post_CloudFailoverStop(HttpClient connect, string UID)
        {
            var res = connect.PostAsync("/api/cloud/cloudFailoverPlans/" + UID.Replace("urn:veeam:CloudFailoverPlan:", "") + "?action=undo", null).Result;
            var con = res.Content.ReadAsStringAsync().Result;
            return con;
        }





        public bool subscribeTask(HttpClient connect, string id)
        {
            var res = connect.GetAsync("/api/tasks/" + id).Result;
            var con = res.Content.ReadAsStringAsync().Result;

            XmlDocument s = new XmlDocument();
            s.LoadXml(con);
            try
            {
                string taskId = s.GetElementsByTagName("TaskId")[0].InnerText;
                string state = s.GetElementsByTagName("State")[0].InnerText;
                string operation = s.GetElementsByTagName("Operation")[0].InnerText;
                var result = s.GetElementsByTagName("Result")[0].Attributes[0].InnerXml;

                if (result == "true")
                    return true;
                else
                    return false;
            }
            catch
            {
                System.Threading.Thread.Sleep(10000);
                res = connect.GetAsync("/api/tasks/" + id).Result;
                con = res.Content.ReadAsStringAsync().Result;
                s.LoadXml(con);
                string taskId = s.GetElementsByTagName("TaskId")[0].InnerText;
                string state = s.GetElementsByTagName("State")[0].InnerText;
                string operation = s.GetElementsByTagName("Operation")[0].InnerText;
                var result = s.GetElementsByTagName("Result")[0].Attributes[0].InnerXml;

                if (result == "true")
                    return true;
                else
                    return false;
            }
        }
    }
}
