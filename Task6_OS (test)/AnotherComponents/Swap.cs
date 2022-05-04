using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class Swap
    {
        private static Swap _instance;
        public static Swap Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Swap();
                }
                return _instance;
            }
        }
        public List<Process> Processes { get; set; }

        private Swap()
        {
            Processes = new List<Process>();
        }
    }
}
