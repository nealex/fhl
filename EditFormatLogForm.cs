using fhl.core;
using System;
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
    public partial class EditFormatLogForm : Form
    {
        public EditFormatLogForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Строка содержащая формат лога не может быть пустой!!!");
                return;
            }
            Properties.Settings.Default.WS_log_format =  fhl_core.ws_cfg.log_format = textBox1.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
