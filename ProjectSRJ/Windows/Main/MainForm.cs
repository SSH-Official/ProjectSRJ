using ProjectSRJ.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSRJ
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyPartyForm theForm = new MyPartyForm();
            theForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindPartyForm theForm = new FindPartyForm();
            theForm.Show();
        }
    }
}
