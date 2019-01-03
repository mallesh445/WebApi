using BusinessObjects;
using Newtonsoft.Json;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace WebApiWithSwagger.Controllers
{
    public class ModulesController : ApiController
    {
        Service service = new Service();

       [ActionName("GetScriptDetailsDataByScriptQuery")]
        [HttpPost]
        public IHttpActionResult GetScriptDetailsDataByScriptQuery(ScriptEntity scriptEntity)
        {
            try
            {
                //data = "Select * from Warehousereceivingorder where RequestId = 112656 and UserId = 209478";//dummy request data
                object scriptInfo = null;
                scriptInfo = service.RetrieveScriptDetailsDataByWhereData(scriptEntity);//id is ScriptId
                if (scriptInfo == null)
                {
                    return BadRequest("Data Not found");
                }
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ActionName("UpdateQueryTitleByQueryId")]
        [HttpPost]
        public IHttpActionResult UpdateQueryTitleByQueryId(string id,string title)
        {
            try
            {
                //data = "Select * from Warehousereceivingorder where RequestId = 112656 and UserId = 209478";//dummy request data
                object scriptInfo = null;
                //scriptInfo = service.RetrieveScriptDetailsDataByWhereData(scriptEntity);//id is ScriptId
                if (scriptInfo == null)
                {
                    return BadRequest("Data Not found");
                }
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult InsertNewQueryInScripts(string data)
        {
            try
            {
                object scriptInfo = null;
                ModuleEntity moduleEntity= JsonConvert.DeserializeObject<ModuleEntity>(data);
                scriptInfo = service.InsertNewQueryInScripts(moduleEntity);//id is ScriptId
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IHttpActionResult UpdateExistingQueryInScripts(string data)
        {
            try
            {
                object scriptInfo = null;
                ModuleEntity moduleEntity = JsonConvert.DeserializeObject<ModuleEntity>(data);
                scriptInfo = service.UpdateExistingQueryInScripts(moduleEntity);//id is ScriptId
                if (scriptInfo == null)
                {
                    return null;
                }
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //gg
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
                return Ok(ex.Message);
            }
        }
        [HttpGet]
        public IHttpActionResult GetModuleListbyModuleId(int id)
        {
            try
            {
                object modules = null;
                modules = service.GetModuleListbyModuleId(id);
                return Json(modules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IHttpActionResult RetrieveScriptDetailsByScriptId(int id)
        {
            try
            {
                object scriptInfo = null;
                scriptInfo = service.GetScriptdetailsbyScriptId(id);//id is ScriptId
                string json = JsonConvert.SerializeObject(scriptInfo);
                if (scriptInfo == null)
                {
                    return null;
                }
                return Ok(scriptInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}