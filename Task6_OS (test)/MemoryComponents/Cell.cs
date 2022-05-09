using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6_OS
{
    public class Cell
    {
        private static int id = 0;
        private Process process;

        public int Id { get; private set; }
        public CheckBox Check { get; set; }
        public Process Process
        {
            get
            {
                return process;
            }
            set
            {
                if (Check != null)
                {
                    if (value != null)
                    {
                        Check.Checked = true;
                    } else
                    {
                        Check.Checked = false;
                    }
                }
                process = value;
            }
        }
        public Cell()
        {
            Id = id++;
        }
    }
}
