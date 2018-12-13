using BusinessObjects;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiWithSwagger.Controllers
{
    public class ModulesController : ApiController
    {
        Service service = new Service();
         
        [ActionName("GetScriptDetailsDataByScriptQuery")]
        [HttpGet]
        public IHttpActionResult GetScriptDetailsDataByScriptQuery(string data)
        {
            try
            {
                //data = "Select * from Warehousereceivingorder where RequestId = 112656 and UserId = 209478";//dummy request data
                object scriptInfo = null;
                scriptInfo = service.RetrieveScriptDetailsDataByWhereData(data);//id is ScriptId
                if (scriptInfo == null)
                {

                    return null;
                }
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult InsertNewQueryInScripts(string data)
        {
            try
            {
                object scriptInfo = null;
                scriptInfo = service.InsertNewQueryInScripts(data);//id is ScriptId
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet]
        public IHttpActionResult UpdateExistingQueryInScripts(string data)
        {
            try
            {
                object scriptInfo = null;
                scriptInfo = service.UpdateExistingQueryInScripts(data);//id is ScriptId
                if (scriptInfo == null)
                {
                    return null;
                }
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllModules(int id = 0)
        {
            try
            {
                object modules = null;
                if (id == 0)
                {
                    modules = service.GetAllModuleFromDb();
                }
                else
                {
                   // modules = service.GetModuleListbyModuleId(id);
                }
                if (modules == null)
                {
                    return NotFound();
                }
                return Json(modules);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult GetModuleListbyModuleId(string id)
        {
            try
            {
                object modules = null;
                modules = service.GetModuleListbyModuleId(id);                
                return Json(modules);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IHttpActionResult RetrieveScriptDetailsByScriptId(int id)
        {
            try
            {
                object scriptInfo = null;
                scriptInfo = service.GetScriptdetailsbyScriptId(id);//id is ScriptId
                if (scriptInfo == null)
                {
                    return null;
                }
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
