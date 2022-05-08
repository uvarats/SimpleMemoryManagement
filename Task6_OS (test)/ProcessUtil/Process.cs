using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class Process
    {
        private static int id = 1;
        private Thread innerThread;
        public int Id { get; private set; }
        public int Size { get; private set; }
        public DateTime LastAction { get; private set; }
        public ProcessState State { get; set; }
        public ProcessLocation Location { get; set; }
        public Process(int size)
        {
            Id = id++;
            Size = size;
            LastAction = DateTime.Now;
            State = ProcessState.DoingSomething;
            Location = ProcessLocation.InMemory;
        }
        private void DoSomething()
        {
            innerThread = new Thread(
                () =>
                {
                    while (true)
                    {
                        Thread.Sleep(30000);
                        Random r = new Random();
                        int number = r.Next(0, 100);
                        State = number % 3 != 0 ? ProcessState.DoingSomething : ProcessState.Sleeping;
                        Console.WriteLine($"{Id} - {State}");
                        if (State == ProcessState.DoingSomething)
                        {
                            CPU.GetInstance();
                        }
                    }
                }
            );
            innerThread.Start();
        }
    }
}
