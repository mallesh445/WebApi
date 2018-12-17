using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Serializable]
    public class ModuleEntity
    {
        private int selectedModule;

        public int SelectedModule
        {
            get { return selectedModule; }
            set { selectedModule = value; }
        }

        private int selectedOperation;

        public int SelectedOperation
        {
            get { return selectedOperation; }
            set { selectedOperation = value; }
        }

        private string builtQuery;

        public string BuiltQuery
        {
            get { return builtQuery; }
            set { builtQuery = value; }
        }

        private string queryTitle;

        public string QueryTitle
        {
            get { return queryTitle; }
            set { queryTitle = value; }
        }
        
    }
}
