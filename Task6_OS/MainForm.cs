using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task6_OS.Properties;

namespace Task6_OS
{
    public partial class MainForm : Form
    {
        private CPU cpu;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            const int maxCellsPerLine = 32;

            MemorySetupForm setupForm = new MemorySetupForm();
            if (setupForm.ShowDialog() != DialogResult.OK)
                return;

            cpu = CPU.GetInstance();

            int memorySize = cpu.Memory.Size;
            int segmentSize = cpu.Memory.SegmentSize;

            int totalLines = (int) Math.Ceiling(memorySize * 1.0 / maxCellsPerLine);
            int segmentsPerLine = maxCellsPerLine / segmentSize;

            // обработать ситуацию, когда ячеек меньше, чем 32
            
            int X = 20;
            int Y = 30;

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
        }

        private void compactMemoryButton_Click(object sender, EventArgs e)
        {
            cpu.Memory.Compact();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            int processSize = Convert.ToInt32(processSizeUpDown.Value);
            LoadingResult result = cpu.LoadProcess(new Process(processSize));
            switch (result)
            {
                case LoadingResult.Success:
                    break;
                case LoadingResult.NotEnoughMemory:
                    MessageBox.Show("Недосточно памяти.");
                    break;
                case LoadingResult.CannotFindFreeSpace:
                    MessageBox.Show("Невозможно найти свободное пространство, попробуйте уплотнить память.");
                    break;
                case LoadingResult.ProcessSizeIsNull:
                    break;
                case LoadingResult.Unknown:
                    break;
                default:
                    break;
            }
        }
    }
}
