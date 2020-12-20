using System;
using fhl.core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fhl
{
    public partial class FormWhiteIPList : Form
    {
        public FormWhiteIPList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fhl_core.WhiteIPList = textBox1.Text.Split(',').ToList();
            this.Close();
        }
    }
}
