using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fhl.core;

namespace fhl
{
    public partial class FormNumberOfThreadsAtWork : Form
    {
        public FormNumberOfThreadsAtWork()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fhl_core.ThreadParse = trackBar1.Value;
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Выбрано потоков: " + trackBar1.Value;
        }
    }
}
