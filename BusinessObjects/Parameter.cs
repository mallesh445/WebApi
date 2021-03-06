﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    //[Serializable]
    public class Parameter
    {
        public string parameterName { get; set; }
        public string parameterValue { get; set; }
        public bool required { get; set; }
        public string label { get; set; }
        public string controlType { get; set; }
    }
}
