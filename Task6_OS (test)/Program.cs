using System;

namespace Task6_OS
{
    public class Program
    {
        static void Main(string[] args)
        {
            CPU cpu = CPU.GetInstance(512, 4);
            cpu.LoadProcess(new Process(32));
            cpu.Memory.Visualize();
        }
    }
}
