using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ScriptEntity
    {
        public int ScriptId { get; set; }
        public int ModuleId { get; set; }
        public int OperationId { get; set; }
        public string Script { get; set; }
        public string Table { get; set; }
        public string Title { get; set; }

        public List<Parameter> Parameters { get; set; }

        //private List<Parameters> parameters1;

        //public List<Parameters> Getparameters()
        //{
        //    return parameters1;
        //}

        //public void Setparameters(List<Parameters> value)
        //{
        //    parameters1 = value;
        //}
    }
}
