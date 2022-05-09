using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6_OS
{
    public partial class MainForm : Form
    {
        private CPU cpu;
        private Timer testTimer;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            const int maxCellsPerLine = 32;

            int memorySize = 512;
            int segmentSize = 4;

            cpu = CPU.GetInstance(memorySize, segmentSize);

            int totalLines = memorySize / maxCellsPerLine;
            int segmentsPerLine = maxCellsPerLine / segmentSize;
            
            int X = 20;
            int Y = 20;

            var segment = cpu.Memory.Segments.First;
            
            for (int i = 0; i < totalLines; i++)
            {
                for (int j = 0; j < segmentsPerLine; j++)
                {
                    if (segment == null)
                    {
                        return;
                    }
                    for (int z = 0; z < segmentSize; z++)
                    {
                        CheckBox b = new CheckBox();
                        b.AutoSize = true;
                        b.Text = "";
                        b.AutoCheck = false;
                        b.Location = new Point(X, Y);

                        segment.Value.Cells[z].Check = b;
                        Controls.Add(b);
                        X += 20;
                    }
                    segment = segment.Next;
                    X += 5;
                }
                X = 20;
                Y += 20;
            }
            cpu.LoadProcess(new Process(50));
            cpu.LoadProcess(new Process(120));
            testTimer = new Timer();
            testTimer.Tick += (s, e) => 
            {
                Random r = new Random();
                cpu.LoadProcess(new Process(r.Next(4, 64)));
            };
            testTimer.Interval = 5000;
            testTimer.Start();
        }
    }
}
