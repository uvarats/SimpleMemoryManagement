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
        public static CPU GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CPU(512, 4);
            }
            return _instance;
        }
        private void UnloadSleeping()
        {
            foreach (var process in Memory.Processes)
            {
                if (process.Process.State == ProcessState.Sleeping)
                {
                    Memory.Unload(process.Process);
                    Swap.Add(process.Process);
                    process.Process.Location = ProcessLocation.InSwap;
                }
            }
        }
        public bool LoadProcess(Process process)
        {
            if (process.Size > Memory.Size)
            {
                return false;
            }
            LoadingResult loadingResult = LoadingResult.Unknown;
            while (loadingResult != LoadingResult.Success)
            {
                loadingResult = Memory.TryLoad(process);
                switch (loadingResult)
                {
                    case LoadingResult.NotEnoughMemory:
                        UnloadSleeping();
                        break;
                    case LoadingResult.CannotFindFreeSpace:
                        Memory.Compact();
                        break;
                    case LoadingResult.ProcessSizeIsNull:
                    case LoadingResult.Unknown:
                        throw new ArgumentException($"{process.Id} - {loadingResult}");
                    default:
                        break;
                }
            }
            return true;
        }
        public void Action(Process process)
        {
            if (process.Location == ProcessLocation.InSwap)
            {
                Swap.Processes.Remove(process);
                LoadProcess(process);
                process.Location = ProcessLocation.InMemory;
            }
        }
    }
}
