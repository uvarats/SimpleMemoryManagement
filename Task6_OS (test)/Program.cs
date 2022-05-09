using System;

namespace Task6_OS
{
    public class Program
    {
        static void Main(string[] args)
        {
            CPU cpu = CPU.GetInstance(512, 4);
            cpu.Memory.TryLoad(new Process(512));
            cpu.Memory.FindFreeSpace(200);
        }
    }
}
