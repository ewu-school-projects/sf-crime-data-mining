using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFCrimeDatabaseService
{
    public class NotFoundException : Exception
    {
        public string Item { get; set; }

        public NotFoundException(string item)
        {
            Item = item;
        }
    }
}
