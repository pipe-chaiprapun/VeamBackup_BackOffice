using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.BackupObject;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Inventory;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Inventory.Info;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Job;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Job.Info;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Repository;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Repository.Info;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Tenant;
using Backup.ClassLibrary.Concrete.Nakivo.NakivoModel.Tenant.Info;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backup.ClassLibrary.Concrete.Nakivo
{
    public class NakivoAPI : INakivoAPI
    {
        private const string Host = "https://10.50.18.9:4443";
        private const string Host2 = "https://127.0.0.1:4443";
        private const string Auth = @"{'action': 'AuthenticationManagement','method': 'login','data': ['admin', 'Nakivo123!', false],'type': 'rpc','tid': 1}";
        private const string logout = "{'action': 'AuthenticationManagement','method': 'logoutCurrentUser','data': ['admin', 'Nakivo123!', false],'type': 'rpc','tid': 1}";
        private const string Auth2 = @"{'action': 'AuthenticationManagement','method': 'login','data': ['admin0005', '1135', false],'type': 'rpc','tid': 1}";
        private enum viewType { VIRTUAL_ENVIRONMENT, HYPERV_VIRTUAL_ENVIRONMENT, AWS_ENVIRONMENT };

        #region Authentication Management
        private static bool AllwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        public HttpClient ConnectNakivo_API()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AllwaysGoodCertificate);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Host);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(Auth, Encoding.UTF8, "application/json");

            var sessionResponse = client.PostAsync("/c/router", content).Result;
            sessionResponse.EnsureSuccessStatusCode();
            string con = sessionResponse.Content.ReadAsStringAsync().Result;
            // var model = JsonConvert.DeserializeObject<Login>(con);

            var ss = sessionResponse.Headers.GetValues("set-cookie").FirstOrDefault();
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("set-cookie", ss);
            return client;

        }
        public bool LoginStateCheck()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AllwaysGoodCertificate);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Host);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string action = @"{
                              'action': 'AuthenticationManagement',
                              'method': 'isLogged',
                              'data': ['admin', null, false],
                              'type': 'rpc',
                              'tid': 1
                            }";

            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = client.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var logged = data["data"].Value<bool>();

            return logged;
        }
        public void Logout()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AllwaysGoodCertificate);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Host);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(Auth, Encoding.UTF8, "application/json");

            var sessionResponse = client.PostAsync("/c/router", content).Result;
            sessionResponse.EnsureSuccessStatusCode();
            string con = sessionResponse.Content.ReadAsStringAsync().Result;
        }
        #endregion


        #region Tenancy Management
        public int CreateTenant(HttpClient connection, string vcc, string AdminPassword, string emailAdmin, string emailGuest, string GuestPassword, int vm, int storage, bool premium = false)
        {
            CreateTenant tn = new CreateTenant
            {
                action = "MultitenancyManagement",
                method = "save",
                // data = dt,
                data = new Datum[1]
                {
                    new Datum
                    {
                        tenant = new Tenant
                        {
                            id = 0,
                            name = vcc,
                            email = "",
                            phone = "",
                            website = "",
                            address = "",
                            allocated = vm.ToString(),
                            allocatedEc2Instances = null,
                            showName = true,
                            labels = null
                        },
                        sessionUuid = null,
                        userRequests = new Userrequest[2]
                        {
                            new Userrequest
                            {
                                type = "ADMIN",
                                attributes = new Attributes
                                {
                                    login = "admin"+vcc.Replace("VCC",""),
                                    enabled = true,
                                    password = AdminPassword,
                                    currentPassword = "",
                                    email = emailAdmin,
                                    permissions = null
                                }
                            },
                            new Userrequest
                            {
                                type = "GUEST",
                                attributes = new Attributes
                                {
                                    login = (GuestPassword == null ? null : GuestPassword),
                                    enabled = (GuestPassword == null ? false : true),
                                    password = (GuestPassword == null ? null : GuestPassword),
                                    currentPassword = (GuestPassword == null ? null : ""),
                                    email = emailGuest,
                                    permissions = null
                                }
                            }
                        }
                    }
                },
                type = "rpc",
                tid = 86
            };

            var action = JsonConvert.SerializeObject(tn);
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            int id = data["data"].Value<int>();
            return id;
        }

        public bool DeleteTenant(HttpClient connection, string vcc)
        {
            int id = getTenantByName(connection, vcc).data.items[0].id;
            string action = @"{
                                'action': 'MultitenancyManagement',
                                'method': 'remove',
                                'data': [" + id.ToString() + @",true],
                                'type': 'rpc',
                                'tid': 86
                              }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            string msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        public bool DisableTenant(HttpClient connection, string vcc)
        {
            int id = getTenantByName(connection, vcc).data.items[0].id;
            string action = @"{
                                  'action': 'MultitenancyManagement',
                                  'method': 'disable',
                                  'data': [" + id.ToString() + @",true],
                                  'type': 'rpc',
                                  'tid': 86
                                }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            string msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        public bool EnableTenant(HttpClient connection, string vcc)
        {
            int id = getTenantByName(connection, vcc).data.items[0].id;
            string action = @"{
                                  'action': 'MultitenancyManagement',
                                  'method': 'enable',
                                  'data': [" + id.ToString() + @",true],
                                  'type': 'rpc',
                                  'tid': 86
                                }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            string msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        public ListTenant getListTenants(HttpClient connection)
        {
            string action = @"{'action':'MultitenancyManagement','method':'getTenants','data':[{'filter':{'start':0,'count':1000,'criteria':[]}}],'type':'rpc','tid':92}";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<ListTenant>(con);

            return model;
        }
        public TenantInfo getTenantByName(HttpClient connection, string name)
        {
            string action = @"{
                                'action':'MultitenancyManagement',
                                'method':'getTenants',
                                'data':[{
                                    'filter':{'start':0,
                                        'count':1000,'criteria':[{'name':'NAME','type':'EQ','value':'" + name + @"'}]
                                    }}],
                                'type':'rpc',
                                'tid':92
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<TenantInfo>(con);
            return model;
        }
        public string getUID(TenantInfo tn)
        {
            return tn.data.items.FirstOrDefault().uuid;
        }
        #endregion

        #region Repository Management
        public RepositoryList getRepoList(HttpClient connection)
        {
            string action = @"{
                              'action': 'BackupManagement',
                              'method': 'getBackupRepositories',
                              'data': null,
                              'type': 'rpc',
                              'tid': 1
                              }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<RepositoryList>(con);
            return model;
        }
        public RepositoryInfo getRepoInfo(HttpClient connection)
        {
            string action = @"{
                              'action': 'BackupManagement',
                              'method': 'getBackupRepository',
                              'data': [3],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<RepositoryInfo>(con);
            return model;
        }
        public bool refreshRepo(HttpClient connection)
        {
            string action = @"{
                              'action': 'BackupManagement',
                              'method': 'refreshAll',
                              'data': null,
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();

            if (msg == null)
                return true;
            else
                return false;
        }
        public bool detachRepo(HttpClient connection, int id)
        {
            string action = @"{
                              'action': 'BackupManagement',
                              'method': 'detach',
                              'data': ["+id.ToString()+@"],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        public bool attachRepo(HttpClient connection, int id)
        {
            string action = @"{
                              'action': 'BackupManagement',
                              'method': 'attach',
                              'data': [" + id.ToString() + @"],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        #endregion

        #region Job Management
        public JobList getJobList(HttpClient connection)
        {
            string action = @"{
                              'action': 'JobSummaryManagement',
                              'method': 'getGroupInfo',
                              'data': [[null],0,false],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<JobList>(con);
            return model;
        }
        public JobInfo getJobInfo(HttpClient connection, int id)
        {
            string action = @"{
                              'action': 'JobSummaryManagement',
                              'method': 'getJobInfo',
                              'data': [["+id.ToString()+@"],0],
                              'type': 'rpc',
                              'tid': 1
                             }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<JobInfo>(con);
            return model;
        }
        public bool enableJob(HttpClient connection, int id, bool enable)
        {
            string action = @"{
                              'action': 'JobManagement',
                              'method': 'enable',
                              'data': ["+id.ToString()+@","+enable.ToString()+@"],
                              'type': 'rpc',    
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        public bool runJob(HttpClient connection, int id)
        {
            string action = @"{
                              'action': 'JobManagement',
                              'method': 'run',
                              'data': [{'jobIds':["+id.ToString()+@"],'runType':'ALL'}],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        public bool stopJob(HttpClient connection, int id)
        {
            string action = @"{
                              'action': 'JobManagement',
                              'method': 'stop',
                              'data': [{'jobIds':["+id.ToString()+@"]}],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        public bool removeJob(HttpClient connection, int id)
        {
            string action = @"{
                                'action': 'JobManagement',
                                'method': 'remove',
                                'data': ["+id.ToString()+@",true],
                                'type': 'rpc',
                                'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        #endregion

        #region Backup Ojbect
        public ObjectList getOjectList(HttpClient connection, int id)
        {
            string action = @"{
                              'action': 'BackupManagement',
                              'method': 'getBackupObjects',
                              'data': [{
                                'filter': {
                                  'start': 0,
                                  'count': 9999,
                                  'sort': 'NAME',
                                  'sortAsc': true,
                                  'criteria': [{
                                    'type': 'EQ',
                                    'name': 'REPOSITORY_ID',
                                    'value': "+id.ToString()+@"
                                  }]
                                }
                              }],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<ObjectList>(con);
            return model;
        }
        public bool removeBackupObject(HttpClient connection, int id)
        {
            string action = @"{
                              'action': 'BackupManagement',
                              'method': 'removeBackupObject',
                              'data': [14],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        #endregion

        #region Inventory Management
        public InventoryItems getAllItems(HttpClient connection)
        {
            string action = @"{
                              'action': 'VmwareDiscovery',
                              'method': 'getDiscoveryItems',
                              'data': null,
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<InventoryItems>(con);
            return model;
        }
        public ItemInfo getItemInfo(HttpClient connection, int id)
        {
            string action = @"{
                              'action': 'VmwareDiscovery',
                              'method': 'getDiscoveryItem',
                              'data': ["+id.ToString()+@"],
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<ItemInfo>(con);
            return model;
        }
        public bool refreshInv(HttpClient connection)
        {
            string action = @"{
                              'action': 'VmwareDiscovery',
                              'method': 'refreshAll',
                              'data': null,
                              'type': 'rpc',
                              'tid': 1
                            }";
            var content = new StringContent(action, Encoding.UTF8, "application/json");
            var res = connection.PostAsync("/c/router", content).Result;
            string con = res.Content.ReadAsStringAsync().Result;
            var data = (JObject)JsonConvert.DeserializeObject(con);
            var msg = data["message"].Value<string>();
            if (msg == null)
                return true;
            else
                return false;
        }
        #endregion
    }
}
