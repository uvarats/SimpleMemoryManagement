using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public class Segment
    {
        private static int id = 0;
        public int Id { get; private set; }
        public List<Cell> Cells { get; private set; }
        public Process Process { get; set; }
        public int Size
        {
            get
            {
                return Cells.Count;
            }
        }
        public Segment(int segmentSize)
        {
            Id = id++;
            Cells = new List<Cell>();
            for (int i = 0; i < segmentSize; i++)
            {
                Cells.Add(new Cell());
            }
        }
        public void Clear()
        {
            foreach (var cell in Cells)
            {
                cell.Process = null;
            }
            Process = null;
        }
        public Cell this[int index]
        {
            get
            {
                return Cells[index];
            }
        }
    }
}
