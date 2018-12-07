using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public static class ProjectConstants
    {
        public static string DatabaseString = ConfigurationManager.ConnectionStrings["Live"].ConnectionString;
        public static string InsightsDBString = ConfigurationManager.ConnectionStrings["Insights"].ConnectionString;

    }
}
