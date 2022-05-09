using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

            cpu.Memory.Processes.CollectionChanged += Processes_CollectionChanged;
            cpu.Swap.Processes.CollectionChanged += Processes_CollectionChanged1;

            ToolTip t = new ToolTip();
            int cellsCounter = 0;

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
                        t.SetToolTip(b, $"Ячейка {cellsCounter++}");
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

        private void Processes_CollectionChanged1(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        Process process = item as Process;
                        ListViewItem lvItem = new ListViewItem(process.Id.ToString());
                        lvItem.SubItems.Add(process.Size.ToString());
                        swapList.Items.Add(lvItem);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    swapList.Items.Remove(swapList.SelectedItems[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        private void Processes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        ProcessInfo pInfo = item as ProcessInfo;
                        AddToProcessListView(pInfo);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    memoryList.Items.Remove(memoryList.SelectedItems[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        private void compactMemoryButton_Click(object sender, EventArgs e)
        {
            cpu.Memory.Compact();
            UpdateMemoryListView();
        }
        private void AddToProcessListView(ProcessInfo pInfo)
        {
            ListViewItem lvItem = new ListViewItem(pInfo.Process.Id.ToString());
            lvItem.SubItems.Add(pInfo.Size.ToString());
            lvItem.SubItems.Add(pInfo.FirstSegment.Id.ToString());
            memoryList.Items.Add(lvItem);
        }
        private void UpdateMemoryListView()
        {
            memoryList.Items.Clear();
            foreach (var pInfo in cpu.Memory.Processes)
            {
                AddToProcessListView(pInfo);
            }
        }
        private void CheckResult(LoadingResult result)
        {
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
        private void loadButton_Click(object sender, EventArgs e)
        {
            int processSize = Convert.ToInt32(processSizeUpDown.Value);
            LoadingResult result = cpu.LoadProcess(new Process(processSize));
            CheckResult(result);
        }

        private void memoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (memoryList.SelectedIndices.Count != 0)
            {
                unloadButton.Enabled = true;
                toSwapButton.Enabled = true;
            } else
            {
                unloadButton.Enabled = false;
                toSwapButton.Enabled = false;
            }
        }

        public void MakeActionWithProcess(ListView view, Action<int, ListViewItem> action)
        {
            ListViewItem selectedItem = view.SelectedItems[0];
            int id = Convert.ToInt32(selectedItem.SubItems[0].Text);
            action(id, selectedItem);
        }

        private void unloadButton_Click(object sender, EventArgs e)
        {
            MakeActionWithProcess(memoryList, (id, selectedItem) =>
            {
                cpu.Memory.Unload(id);
                memoryList.Items.Remove(selectedItem);
            });
        }

        private void toSwapButton_Click(object sender, EventArgs e)
        {
            MakeActionWithProcess(memoryList, (id, selectedItem) =>
            {
                cpu.MoveToSwap(id);
            });
        }

        private void swapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (swapList.SelectedIndices.Count != 0)
            {
                fromSwapButton.Enabled = true;
            } else
            {
                fromSwapButton.Enabled = false;
            }
        }

        private void fromSwapButton_Click(object sender, EventArgs e)
        {
            MakeActionWithProcess(swapList, (id, selectedItem) =>
            {
                CheckResult(cpu.MoveFromSwap(id));
            });
        }
    }
}
