using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BackOffice.WebAPI.Controllers
{
    public class PositionController : ApiController
    {
        public IPosition _Position;

        public PositionController(IPosition PositionParam)
        {
            _Position = PositionParam;
        }

        [Route("api/position-all")]
        public IHttpActionResult postPositionAll()
        {
            BO_Messapositio_return zxxz = new BO_Messapositio_return();
            try { 
            return Json(_Position.getPositionAll);
            }
            catch (Exception e)
            {
                zxxz.Message = "UnSuccessful";
                return Json(zxxz);
            }
        }
    }
    public class BO_Messapositio_return
    {
        public string Message { get; set; }
    }
}