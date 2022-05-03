using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class Cell
    {
        private static int id = 0;
        public int Id { get; private set; }
        public Process Process { get; set; }
        public Cell()
        {
            Id = id++;
        }
    }
}
