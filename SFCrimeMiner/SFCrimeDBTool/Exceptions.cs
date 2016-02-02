using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFCrimeDBTool
{
    public class UnsupportedTypeException : Exception
    {
        public string Type { get; set; }

        public UnsupportedTypeException(string type)
        {
            Type = type;
        }
    }
}
