using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Frame;

namespace ProjectSRJ.Windows
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(480, 320);
            progressBar1.Step = 90;
        }

        int turnBack = 3;
        bool isIncreasing = true;
        int dotCount = 0;
        string strLoading = "Loading";

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Visible == false) return;

            string theText_Loading = strLoading;
            
            CalculateTextDots();
            theText_Loading += MultipleDots();

            label_Loading.Text = theText_Loading;

            if (progressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                this.Visible = false;
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }

            progressBar1.PerformStep();

            return;

            void CalculateTextDots()
            {
                if (isIncreasing)
                {
                    dotCount++;
                    if (dotCount >= turnBack) { isIncreasing = false; }
                }
                else
                {
                    dotCount--;
                    if (dotCount <= 0) { isIncreasing = true; }
                }
            }

            string MultipleDots()
            {
                string str = string.Empty;
                for (int i = 0; i < dotCount; i++)
                {
                    str += ".";
                }

                return str;
            }

            
        }

        private void Loading_KeyDown(object sender, KeyEventArgs e)
        {
            //if (this.Visible == false) return;

            if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("Terminating Program...");
                Application.Exit();
            }            
        }


    }
}
