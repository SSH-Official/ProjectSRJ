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
        bool waitForCommand = false;
        bool WaitFormCommand
        {
            get { return waitForCommand; }
            set 
            { 
                waitForCommand = value;
                strLoading = 
                    "##Debugging##\r\n" +
                    "Loading";
            }
        }

        public Loading(bool waitForCommand)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(480, 320);
            progressBar1.Step = 90;
            WaitFormCommand = waitForCommand;
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

            if (progressBar1.Value >= 100 && waitForCommand == false)
            {
                ProceedToNext();
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

        private void ProceedToNext()
        {
            timer1.Enabled = false;
            this.Visible = false;
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();            
        }

        private void Loading_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Visible == false) return;

            if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("프로그램을 종료합니다..");
                Application.Exit();
            }            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 100)
            {
                ProceedToNext();
            }
        }

        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (progressBar1.Value >= 100) { ProceedToNext(); }
            }

            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("연결에 실패했습니다... 다시 시도합니다.");
                progressBar1.Value = 0;
            }
        }
    }
}
