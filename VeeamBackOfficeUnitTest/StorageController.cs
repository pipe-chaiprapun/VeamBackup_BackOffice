using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace VeeamBackOfficeUnit.Test
{
    [TestClass]
    public class StorageController
    {
        private Mock<IVeeamCC> _vcc;
        private BackOffice.WebAPI.Controllers.StorageController storage;

        [TestInitialize]
        public void Initialize()
        {
            _vcc = new Mock<IVeeamCC>();
            storage = new BackOffice.WebAPI.Controllers.StorageController(_vcc.Object);
        }

        [TestMethod]
        public void GetStorage()
        {
            var repo = new Repositories
            {
                Repository = new Repository[]
                    {
                        new Repository {
                            Href = "https://10.50.41.44:9398/api/repositories/c8c19da9-365d-421b-a145-5446ec57b698?format=Entity",
                            Type = "Repository",
                            Name = "HP Repository",
                            UID = "urn:veeam:Repository:c8c19da9-365d-421b-a145-5446ec57b698",
                            Links = new Links{
                                Link = new Link[]{
                                    new Link{ Href = "https://10.50.41.44:9398/api/backupServers/d22bc941-b784-4b30-a8ff-7b66fbcaf00e", Name = "10.50.41.44", Type ="BackupServerReference", Rel ="Up" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/c8c19da9-365d-421b-a145-5446ec57b698", Name = "HP Repository", Type ="RepositoryReference", Rel ="Alternate" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/c8c19da9-365d-421b-a145-5446ec57b698/backups", Type ="BackupReferenceList", Rel ="Down" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/c8c19da9-365d-421b-a145-5446ec57b698/replicas", Type ="ReplicaReferenceList", Rel ="Down" }
                                }
                            },
                            Capacity = "299623354368",
                            FreeSpace = "240365899776"
                        },
                        new Repository {
                            Href = "https://10.50.41.44:9398/api/repositories/a077c2d5-cb97-4090-8b5c-c723c550d09c?format=Entity",
                            Type = "Repository",
                            Name = "QNAP Repository",
                            UID = "urn:veeam:Repository:a077c2d5-cb97-4090-8b5c-c723c550d09c",
                            Links = new Links{
                                Link = new Link[]{
                                    new Link{ Href = "https://10.50.41.44:9398/api/backupServers/d22bc941-b784-4b30-a8ff-7b66fbcaf00e", Name = "10.50.41.44", Type ="BackupServerReference", Rel ="Up" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/a077c2d5-cb97-4090-8b5c-c723c550d09c", Name = "QNAP Repository", Type ="RepositoryReference", Rel ="Alternate" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/a077c2d5-cb97-4090-8b5c-c723c550d09c/backups", Type ="BackupReferenceList", Rel ="Down" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/a077c2d5-cb97-4090-8b5c-c723c550d09c/replicas", Type ="ReplicaReferenceList", Rel ="Down" }
                                }
                            },
                            Capacity = "21968777216",
                            FreeSpace = "21859000320"
                        }
                    }
            };

            //GetRepository  //1048576MB or 1024GB or 1TB
            _vcc.Setup(e => e.SetX_RestSvcSessionId("MGQ5YTMyZTktM2Y0OC00NWQxLWFiYjktMDE0MTM1NmE1M2Vh")).Returns("MGQ5YTMyZTktM2Y0OC00NWQxLWFiYjktMDE0MTM1NmE1M2Vh");
            _vcc.Setup(o => o.getRepositories()).Returns(new Rootobject
            {
                Repositories = new Repositories
                {
                    Repository = new Repository[] 
                    {
                        new Repository {
                            Href = "https://10.50.41.44:9398/api/repositories/c8c19da9-365d-421b-a145-5446ec57b698?format=Entity",
                            Type = "Repository",
                            Name = "HP Repository",
                            UID = "urn:veeam:Repository:c8c19da9-365d-421b-a145-5446ec57b698",
                            Links = new Links{
                                Link = new Link[]{
                                    new Link{ Href = "https://10.50.41.44:9398/api/backupServers/d22bc941-b784-4b30-a8ff-7b66fbcaf00e", Name = "10.50.41.44", Type ="BackupServerReference", Rel ="Up" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/c8c19da9-365d-421b-a145-5446ec57b698", Name = "HP Repository", Type ="RepositoryReference", Rel ="Alternate" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/c8c19da9-365d-421b-a145-5446ec57b698/backups", Type ="BackupReferenceList", Rel ="Down" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/c8c19da9-365d-421b-a145-5446ec57b698/replicas", Type ="ReplicaReferenceList", Rel ="Down" }
                                }
                            },
                            Capacity = "299623354368",
                            FreeSpace = "240365899776"
                        },
                        new Repository {
                            Href = "https://10.50.41.44:9398/api/repositories/a077c2d5-cb97-4090-8b5c-c723c550d09c?format=Entity",
                            Type = "Repository",
                            Name = "QNAP Repository",
                            UID = "urn:veeam:Repository:a077c2d5-cb97-4090-8b5c-c723c550d09c",
                            Links = new Links{
                                Link = new Link[]{
                                    new Link{ Href = "https://10.50.41.44:9398/api/backupServers/d22bc941-b784-4b30-a8ff-7b66fbcaf00e", Name = "10.50.41.44", Type ="BackupServerReference", Rel ="Up" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/a077c2d5-cb97-4090-8b5c-c723c550d09c", Name = "QNAP Repository", Type ="RepositoryReference", Rel ="Alternate" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/a077c2d5-cb97-4090-8b5c-c723c550d09c/backups", Type ="BackupReferenceList", Rel ="Down" },
                                    new Link{ Href = "https://10.50.41.44:9398/api/repositories/a077c2d5-cb97-4090-8b5c-c723c550d09c/replicas", Type ="ReplicaReferenceList", Rel ="Down" }
                                }
                            },
                            Capacity = "21968777216",
                            FreeSpace = "21859000320"
                        }
                    }                   
                }
            });

            //Use method in controller
            var resps = storage.GetStorage();

            var objResult = resps.GetType().GetProperty("Content").GetValue(resps);
            string jsonData = JsonConvert.SerializeObject(objResult);
            var repo_result = JsonConvert.DeserializeObject<List<getRepositories>>(jsonData);

            Assert.IsTrue(repo.Repository.Length == repo_result.Count);
        }
    }
}
