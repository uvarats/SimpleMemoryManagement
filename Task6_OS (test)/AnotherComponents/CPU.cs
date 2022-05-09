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
        private object _lock = new object();
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
        public static CPU GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CPU(512, 4);
            }
            return _instance;
        }
        //private void UnloadSleeping()
        //{
        //    for (int i = 0; i < Memory.Processes.Count; i++)
        //    {
        //        var process = Memory.Processes[i];
        //        if (process.Process.State == ProcessState.Sleeping)
        //        {
        //            Memory.Unload(process);
        //            Swap.Add(process.Process);
        //            process.Process.Location = ProcessLocation.InSwap;
        //            break;
        //        }
        //    }
        //}
        public LoadingResult LoadProcess(Process process)
        {
            return Memory.TryLoad(process);
        }
        //public void Action(Process process)
        //{
        //    if (process.Location == ProcessLocation.InSwap)
        //    {
        //        lock (_lock)
        //        {
        //            Swap.Processes.Remove(process);
        //            LoadProcess(process);
        //            process.Location = ProcessLocation.InMemory;
        //        }
        //    }
        //}
    }
}
