using BusinessObjects;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Service
    { 

        public object GetAllModuleFromDb()
        {
            return RepositoriAPI.GetAllModuleFromDb();
        }

        public object GetModuleListbyModuleId(string moduleId)
        {
            return RepositoriAPI.GetModuleListbyModuleId(moduleId);
        } 

        public object GetScriptdetailsbyScriptId(int scriptId)
        {
            return RepositoriAPI.GetScriptdetailsbyScriptId(scriptId);
        }

        public object RetrieveScriptDetailsDataByWhereData(string data)
        {
            return RepositoriAPI.RetrieveScriptDetailsDataByWhereData(data);
        }

        public object InsertNewQueryInScripts(string data)
        {
            return RepositoriAPI.InsertNewQueryInScriptsInDB(data);
        }

        public object UpdateExistingQueryInScripts(string data)
        {
            return RepositoriAPI.UpdateExistingQueryInScriptsInDB(data);
        }
    }
}
