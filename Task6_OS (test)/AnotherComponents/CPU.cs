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
        public Swap Swap { get; private set; }
        public Memory Memory { get; private set; }
        private CPU(int memorySize, int segmentSize)
        {
            Memory = Memory.GetInstance(memorySize, segmentSize);
            Swap = Swap.Instance;
        }
        public static CPU GetInstance(int memorySize, int segmentSize)
        {
            if (_instance == null)
            {
                _instance = new CPU(memorySize, segmentSize);
            }
            return _instance;
        }
        public void LoadProcess(Process process)
        {
            Memory.Load(process);
        }
    }
}
