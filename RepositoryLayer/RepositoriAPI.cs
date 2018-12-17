using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BusinessObjects;
using System.Threading.Tasks;
using System.Data;

namespace RepositoryLayer
{
    public class RepositoriAPI
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public static object GetScriptdetailsbyScriptId(int scriptId)
        {
            try
            {
                using (ShipbobInsightsEntities sIe = new ShipbobInsightsEntities())
                {
                    var result = sIe.Scripts
                         .Include("Parameters")
                         .Where(s => s.ScriptId == scriptId).ToList();
                    object obj = result;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #region Old code
            //object result = null;
            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(ProjectConstants.InsightsDBString))
            //    {
            //        SqlCommand sqlCommand = new SqlCommand("select * from Scripts where ScriptId=@scriptId;select * from[Parameters] where ScriptId = @scriptId", connection);
            //        sqlCommand.Parameters.AddWithValue("@scriptId", scriptId);

            //        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            //        {
            //            //DataTable table = new DataTable();
            //            DataSet dataSet = new DataSet();

            //            adapter.Fill(dataSet);
            //            if (dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
            //            {

            //            }
            //        }
            //    }

            //catch (Exception e)
            //{
            //    throw;
            //}
            //return result; 
            #endregion
        }

        public static object UpdateExistingQueryInScriptsInDB(ModuleEntity moduleEntity)
        {
            object result = null;
            try
            {
                using (ShipbobInsightsEntities db = new ShipbobInsightsEntities())
                { 
                    Script script = new Script()
                    {
                        Script1 = moduleEntity.BuiltQuery,
                        ModuleId = moduleEntity.SelectedModule,
                        OperationId = moduleEntity.SelectedOperation,
                        Title = moduleEntity.QueryTitle,
                        TableName = moduleEntity.QueryTitle
                    };

                    db.Scripts.Add(script);
                    result = db.SaveChanges();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates New Script in Db
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <returns></returns>
        public static object InsertNewQueryInScriptsInDB(ModuleEntity moduleEntity)
        {
            object result = null;
            try
            {
                using (ShipbobInsightsEntities db = new ShipbobInsightsEntities())
                {
                    Script script = new Script()
                    {
                        Script1 =moduleEntity.BuiltQuery,
                        ModuleId = moduleEntity.SelectedModule,
                        OperationId = moduleEntity.SelectedOperation,
                        Title = moduleEntity.QueryTitle,
                        TableName = moduleEntity.QueryTitle
                    };

                    db.Scripts.Add(script);
                    result = db.SaveChanges();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Getting data by query
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object RetrieveScriptDetailsDataByWhereData(string data)
        {
            object result = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ProjectConstants.DatabaseString))
                {
                    SqlCommand sqlCommand = new SqlCommand(data, connection);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows != null && table.Rows.Count > 0)
                        {
                            result = table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// Get list of module by its id.
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public static object GetModuleListbyModuleId(string moduleName)
        {
            object result = null;
            try
            {
                using (ShipbobInsightsEntities sIe = new ShipbobInsightsEntities())
                {
                    string moduleId = sIe.Modules
                         .Where(s => s.Title == moduleName).Select(c1 => c1.ModuleId).SingleOrDefault().ToString();

                    using (SqlConnection connection = new SqlConnection(ProjectConstants.InsightsDBString))
                    {
                        SqlCommand sqlCommand = new SqlCommand("Select * from Scripts where ModuleId=@moduleid", connection);
                        sqlCommand.Parameters.AddWithValue("@moduleid", Convert.ToInt32(moduleId));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows != null && table.Rows.Count > 0)
                            {
                                result = table;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// Getting list of modules
        /// </summary>
        /// <returns></returns>
        public static object GetAllModuleFromDb()
        {
            object result = null;
            try
            {
                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ProjectConstants.InsightsDBString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("Select Title, ModuleId from Modules ", connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows != null && table.Rows.Count > 0)
                        {
                            result = table;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return result;
        }
        
        
    }
}
