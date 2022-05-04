using System;

namespace Task6_OS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Memory m = new Memory(512, 4);
            try
            {
                m.Load(new Process(50));
                m.Load(new Process(4));
                m.Load(new Process(70));
                m.Load(new Process(32));
                m.Load(new Process(100));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            m.Unload(2);
            m.Unload(4);
            m.Visualize();
            Console.WriteLine(m.FreeMemory);
        }
    }
}
