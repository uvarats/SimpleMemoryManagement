using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class ProcessInfo
    {
        public Process Process { get; private set; }
        public Segment FirstSegment { get; private set; }
        public int Length // в сегментах
        {
            get
            {
                return (int) Math.Ceiling(Process.Size * 1.0 / FirstSegment.Size);
            }
        }
        public int Size // в байтах
        {
            get
            {
                return Process.Size;
            }
        }

        public ProcessInfo(Process process, Segment firstSegment)
        {
            Process = process;
            FirstSegment = firstSegment;
        }
    }
}
