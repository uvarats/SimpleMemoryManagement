using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class Memory
    {
        private static Memory _instance;
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
        public int Size
        {
            get
            {
                return _memorySize;
            }
        }
        private Memory(int memorySize, int segmentSize)
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
        public static Memory GetInstance(int memorySize, int segmentSize)
        {
            if (_instance == null)
            {
                _instance = new Memory(memorySize, segmentSize);
            }
            return _instance;
        }

        public LoadingResult TryLoad(Process process)
        {
            int neededSegments = (int) Math.Ceiling(process.Size * 1.0 / _segmentSize);
            if (neededSegments > FreeMemory)
            {
                return LoadingResult.NotEnoughMemory;
            }
            if (neededSegments != 0)
            {
                Segment firstSegment = FindFreeSpace(neededSegments);
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
                    return LoadingResult.Success;
                }
                return LoadingResult.CannotFindFreeSpace;
            }
            return LoadingResult.ProcessSizeIsNull;
        }
        public void Unload(ProcessInfo processInfo)
        {
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
        public void Unload(int id)
        {
            ProcessInfo processInfo = Processes.Find(pInfo => pInfo.Process.Id == id);
            Unload(processInfo);
        }
        public void Unload(Process process)
        {
            Unload(process.Id);
        }
        private Segment FirstFreeSegment(List<Segment> segments)
        {
            for (int i = 0; i < segments.Count; i++)
            {
                if (segments[i].Process == null)
                {
                    return segments[i];
                }
            }
            return null;
        }
        private Segment FindFreeSpace(int neededSegments)
        {
            List<Segment> segments = new List<Segment>(Segments);
            Segment firstFreeSegment = FirstFreeSegment(segments);

            int startSegment = segments.IndexOf(firstFreeSegment);
            int segmentsCounter = 0; 
            for (int i = startSegment; i < segments.Count; i++)
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
        public void Compact() // функция уплотнения
        {
            List<Segment> segments = new List<Segment>(Segments);
            var firstFreeNode = Segments.Find(FirstFreeSegment(segments));
            var firstAssignedNode = firstFreeNode.Next; // предполагаю, что следующий сегмент уже занят процессом
            while (firstAssignedNode != null)
            {
                while (firstAssignedNode != null && firstAssignedNode.ValueRef.Process == null)
                {
                    firstAssignedNode = firstAssignedNode.Next;
                }
                if (firstAssignedNode != null)
                {
                    Processes.Find(pInfo => pInfo.Process == firstAssignedNode.ValueRef.Process)
                        .FirstSegment = firstFreeNode.ValueRef;
                    // цикл до тех пор, пока не "упрусь" в конец памяти, либо не дойду до свободного сегмента
                    while (firstAssignedNode != null && firstAssignedNode.ValueRef.Process != null)
                    {
                        // перезапись ячеек
                        for (int i = 0; i < _segmentSize; i++)
                        {
                            firstFreeNode.ValueRef.Cells[i].Process = firstAssignedNode.ValueRef.Cells[i].Process;
                        }
                        firstFreeNode.ValueRef.Process = firstAssignedNode.ValueRef.Process;
                        firstAssignedNode.ValueRef.Clear();
                        // перевод указателей вперед
                        firstFreeNode = firstFreeNode.Next;
                        firstAssignedNode = firstAssignedNode.Next;
                    }
                }
            }
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
