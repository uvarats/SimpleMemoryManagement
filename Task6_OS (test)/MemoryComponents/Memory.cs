using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class Memory
    {
        private readonly int _memorySize;
        private readonly int _segmentSize;
        public LinkedList<Segment> Segments { get; private set; }
        public List<ProcessInfo> Processes { get; private set; }
        public int FreeMemory
        {
            get
            {
                int Count = 0;
                foreach (var segment in Segments)
                {
                    if (segment.Process == null)
                    {
                        Count++;
                    }
                }
                return Count;
            }
        }
        public Memory(int memorySize, int segmentSize)
        {
            _memorySize = memorySize;
            _segmentSize = segmentSize;
            Processes = new List<ProcessInfo>();
            Segments = new LinkedList<Segment>();
            int segmentsCount = memorySize / segmentSize;
            for (int i = 0; i < segmentsCount; i++)
            {
                Segments.AddLast(new Segment(segmentSize));
            }
        }

        public void Load(Process process)
        {
            int neededSegments = (int) Math.Ceiling(process.Size * 1.0 / _segmentSize);
            if (neededSegments != 0)
            {
                Segment firstSegment = FindFreeSpace(neededSegments);

                if(firstSegment == null)
                {
                    throw new AggregateException($"Process {process.Id} too large, can not find free space.");
                }

                if (firstSegment != null)
                {
                    var node = Segments.Find(firstSegment);
                    int bytesRemaining = process.Size;
                    while (bytesRemaining != 0)
                    {
                        node.ValueRef.Process = process;
                        for (int i = 0; i < _segmentSize; i++)
                        {
                            node.ValueRef.Cells[i].Process = process;
                            bytesRemaining--;
                            if (bytesRemaining == 0)
                                break;
                        }
                        node = node.Next;
                    }
                    ProcessInfo processInfo = new ProcessInfo(process, firstSegment);
                    Processes.Add(processInfo);
                }
            }
        }
        public void Unload(int id)
        {
            ProcessInfo processInfo = Processes.Find(pInfo => pInfo.Process.Id == id);
            if (processInfo != null)
            {
                var node = Segments.Find(processInfo.FirstSegment);
                for (int i = 0; i < processInfo.Length; i++)
                {
                    node.ValueRef.Clear();
                    node = node.Next;
                }
                Processes.Remove(processInfo);
            }
        }
        private Segment FindFreeSpace(int neededSegments)
        {
            int firstFreeSegment = 0;
            List<Segment> segments = new List<Segment>(Segments);
            for (int i = 0; i < segments.Count; i++)
            {
                if (segments[i].Process == null)
                {
                    firstFreeSegment = i;
                    break;
                }
            }

            int startSegment = firstFreeSegment;
            int segmentsCounter = 0; // так как уже как минимум первый сегмент свободен
            // соответственно начинаем считать со следующего
            for (int i = firstFreeSegment; i < segments.Count; i++)
            {
                if (segments[i].Process == null)
                {
                    segmentsCounter++;
                } else
                {
                    startSegment = i + 1;
                    segmentsCounter = 0;
                    continue; // не имеет смысла выполнять следующую проверку.
                }

                if (segmentsCounter == neededSegments)
                {
                    return segments[startSegment];
                }
            }
            return null;
        }
        public override string ToString()
        {
            return $"Segments: {Segments.Count}. Segment size: {_segmentSize}";
        }
        public void Visualize()
        {
            foreach (var segment in Segments)
            {
                foreach (var cell in segment.Cells)
                {
                    Console.Write(cell.Process != null ? cell.Process.Id : 0);
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public Segment this[int index]
        {
            get
            {
                return Segments.ElementAt(index);
            }
        }
    }
}
