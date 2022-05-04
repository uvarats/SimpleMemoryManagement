using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class CPU
    {
        private static CPU _instance;
        public static CPU Instance 
        { 
            get 
            {
                if (_instance == null)
                {
                    _instance = new CPU();
                }
                return _instance;
            }
        }
    }
}
