using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackOffice.WebAPI.Authen;
using BackOffice.WebAPI.Models;
using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Concrete.Security;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;
using Newtonsoft.Json.Linq;

namespace BackOffice.WebAPI.Controllers
{
    [JWTAuthorize("SuperAdmin", "Admin", "Supervisor", "Operator", "Manager")]
    public class ProlongController : ApiController
    {
        private IPackages _IPack;
        private IProlongPackage _IProl;
        private IUpgradePackage _UpPackage;
        public ProlongController(IPackages pck,IProlongPackage pro, IUpgradePackage UpPackage) {
            this._IPack = pck;
            this._IProl = pro;
            this._UpPackage = UpPackage;
        }
        [Route("api/GanerateInvoiceProlong")]
        public IHttpActionResult PostGanerateInvoiceProlong([FromBody] m_Prolong value)
        {
            if (value.pck_type_id == 11) // 11 is veeam backup
            {
                var res = _IProl.ProlongPackage_VeeamBackup(value.custID, value.VccId);
                if (res != null) {
                    return Json(res);
                }
                return BadRequest("create package fail");
                //Prolong package for Enterprise
            }
            else if (value.pck_type_id == 12)//12 is veeam raplication
            {
                var res = _IProl.ProlongPackage_VeeamReplication(value.custID, value.VccId);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("create package fail");
                 //Prolong package for Enterprise
            }
            else if (value.pck_type_id == 13)//13 is Nakivo backup
            {
                var res = _IProl.ProlongPackage_NakivoBackup(value.custID, value.VccId);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("create package fail");
                //Prolong package for Enterprise
            }
            else
            {
                return Ok("Type package incorrent for enterprise");
            }
        }
        [Route("api/GanerateInvoiceProlongResaller")]
        public IHttpActionResult PostGanerateInvoiceProlongResaller([FromBody] m_Prolong value)
        {
            if (value.pck_type_id == 11) // 11 is veeam backup 
            {
                var res = _IProl.ProlongPackage_VeeamBackupResaller(value.custID, value.VccId);
                if (res != null) {
                    return Json(res);
                }
                return BadRequest("create package fail");
                //Prolong package for Rasaller
            }
            else if (value.pck_type_id == 12)//12 is veeam raplication
            {
                var res = _IProl.ProlongPackage_VeeamReplicationResaller(value.custID, value.VccId);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("create package fail"); //Prolong package for Rasaller
            }
            else if (value.pck_type_id == 13)//13 is Nakivo backup
            {
                var res = _IProl.ProlongPackage_NakivoBackupResaller(value.custID, value.VccId);
                if (res != null)
                {
                    return Json(res);
                }
                return BadRequest("create package fail");
                //Prolong package for Enterprise
            }
            else
            {
                return BadRequest("Type package incorrent for resaller");
            }
        }

    }
}
 