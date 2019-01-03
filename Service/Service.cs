using BusinessObjects;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Service
    {

        public object GetAllModuleFromDb()
        {
            return RepositoriAPI.GetAllModuleFromDb();
        }

        public object GetModuleListbyModuleId(int moduleId)
        {
            return RepositoriAPI.GetModuleListbyModuleId(moduleId);
        }

        public ScriptEntity GetScriptdetailsbyScriptId(int scriptId)
        {
            ScriptEntity scriptEntity = new ScriptEntity();
            List<Script> sData = RepositoriAPI.GetScriptdetailsbyScriptId(scriptId);
            scriptEntity.ModuleId = sData[0].ModuleId;
            scriptEntity.OperationId = sData[0].OperationId;
            scriptEntity.ScriptId = sData[0].ScriptId;
            scriptEntity.Script = sData[0].Script1;
            scriptEntity.Title = sData[0].Title;
            scriptEntity.Table = sData[0].TableName;

            scriptEntity.Parameters = new List<BusinessObjects.Parameter>();
            List<BusinessObjects.Parameter> listParms = new List<BusinessObjects.Parameter>();
            foreach (Match match in Regex.Matches(sData[0].Script1, @"(?<!\w)@\w+"))
            {
                BusinessObjects.Parameter parameter = new BusinessObjects.Parameter();
                parameter.parameterName = match.Value;
                parameter.controlType = "textbox";
                parameter.label = match.Value.Substring(1);
                parameter.required = true;
                listParms.Add(parameter);
                scriptEntity.Parameters.Add(parameter);
            }
            //scriptEntity.Setparameters(listParms);
            return scriptEntity;
            //return RepositoriAPI.GetScriptdetailsbyScriptId(scriptId);
        }

        public object RetrieveScriptDetailsDataByWhereData(ScriptEntity scriptEntity)
        {
            return RepositoriAPI.RetrieveScriptDetailsDataByWhereData(scriptEntity);
        }

        public object InsertNewQueryInScripts(ModuleEntity moduleEntity)
        {
            return RepositoriAPI.InsertNewQueryInScriptsInDB(moduleEntity);
        }

        public object UpdateExistingQueryInScripts(ModuleEntity moduleEntity)
        {
            return RepositoriAPI.UpdateExistingQueryInScriptsInDB(moduleEntity);
        }
    }
}
