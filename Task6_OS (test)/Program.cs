using System;

namespace Task6_OS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Memory m = new Memory(512, 3);
            try
            {
                m.Load(new Process(50));
                m.Load(new Process(4));
                m.Load(new Process(500));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            m.Visualize();
        }
    }
}
