using Lib.Frame;
using ProjectSRJ.Windows.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectSRJ.Windows.MK2Features
{
    public partial class FindPartyView : MasterView
    {
        List<Control> CreatedControls = new List<Control>();
        MainForm_MK2 ParentForm;
        public FindPartyView(MainForm_MK2 parent)
        {
            InitializeComponent();
            ParentForm = parent;

            for (int i = 0; i < 100; i++)
            {
                Label newComp = new Label();
                //sendRequest("requestUserinfo : {UIASDP{Fasdf}");
                newComp.Parent = panel_PostBoard;
                newComp.Size = new Size(panel_PostBoard.Width, 50);
                newComp.Location = new Point(0, 50 * i);
                newComp.Dock = DockStyle.Top;
                newComp.Text = i.ToString();
                newComp.BorderStyle = BorderStyle.FixedSingle;
                panel_PostBoard.Controls.Add(newComp);
                CreatedControls.Add(newComp);                
            }

            Console.WriteLine($"Created : {CreatedControls.Count}");
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                vScrollBar1.Value += e.Delta;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int scrollValue = vScrollBar1.Value;
            panel_PostBoard.AutoScrollPosition = new System.Drawing.Point(0, scrollValue);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
