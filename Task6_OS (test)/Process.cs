using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class Process
    {
        private static int id = 1;
        public int Id { get; private set; }
        public int Size { get; private set; }
        public Process(int size)
        {
            Id = id++;
            Size = size;
        }
    }
}
