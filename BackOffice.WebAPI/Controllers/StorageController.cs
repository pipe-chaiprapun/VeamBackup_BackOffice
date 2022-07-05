using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    public class StorageController : ApiController
    {
        private IVeeamCC _vcc;
        public StorageController(IVeeamCC vcc)
        {
            this._vcc = vcc;
        }

        [Route("api/storage")]
        public IHttpActionResult GetStorage()
        {
            var s = _vcc.getRepositories();

            List<getRepositories> list_repo = new List<getRepositories>();
            foreach(var n in s.Repositories.Repository)
            {
                getRepositories re = new getRepositories
                {
                    name = n.Name,
                    capacity = n.Capacity.ToString(),//(Convert.ToDecimal(n.Capacity) / Convert.ToDecimal(Math.Pow(1024,3))).ToString("0.##"),
                    freeSpace = n.FreeSpace.ToString()//(Convert.ToDecimal(n.FreeSpace) / Convert.ToDecimal(Math.Pow(1024, 3))).ToString("0.##"),
                };
               /* getRepositories re2 = new getRepositories
                {
                    name = n.Name,
                    capacity = (Convert.ToDecimal(n.Capacity) / Convert.ToDecimal(Math.Pow(1024, 3))).ToString(),
                    freeSpace = (Convert.ToDecimal(n.FreeSpace) / Convert.ToDecimal(Math.Pow(1024, 3))).ToString(),
                };
                System.Console.Write(re2);*/
                list_repo.Add(re);
            }

            return Json(list_repo);
        }
        
    }
}
