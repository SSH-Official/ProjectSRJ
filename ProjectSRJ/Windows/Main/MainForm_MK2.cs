using Lib.Frame;
using ProjectSRJ.Windows.MK2Features;
using ProjectSRJ.Windows.MK2Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSRJ.Windows.Main
{
    public partial class MainForm_MK2 : Form
    {
        List<MasterView> Views;
        public MainForm_MK2()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => Application.Exit();

            InitializeViews();

            void InitializeViews()
            {
                this.Views = new List<MasterView>
            {
                new MyPartyView(),
                new FindPartyView()
            };

                foreach (MasterView view in this.Views)
                {
                    view.Parent = panel_Fill;
                    view.Dock = DockStyle.Fill;
                    view.Visible = false;
                }

                ShowView<MyPartyView>();
            }
        }

        private void ShowView<T>()
        {
            ShowView(typeof(T));
        }

        private void ShowView(Type aType)
        {
            HideAllView();
            GetView(aType).Visible = true;
            GetView(aType).Refresh_View();
        }
        private void HideAllView()
        {
            foreach (MasterView view in this.Views)
            { view.Visible = false; }
        }
        private MasterView GetView(Type aType)
        {
            foreach (MasterView view in this.Views)
            {
                if (view.GetType() == aType)
                { return view; }
            }
            return null;
        }

        private void panel_Option01_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ShowView<FindPartyView>();
        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void panel_Fill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            ShowView<FindPartyView>();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ShowView<MyPartyView>();
        }
    }
}
