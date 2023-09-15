using Lib.Frame;
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
        public FindPartyView()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                Label newComp = new Label();
                //sendRequest("requestUserinfo : {UIASDP{Fasdf}");
                newComp.Parent = flowLayoutPanel1;
                newComp.Size = new Size(flowLayoutPanel1.Width, 50);
                newComp.Location = new Point(0, 50 * i);
                newComp.Dock = DockStyle.Top;
                newComp.Text = i.ToString();
                newComp.BorderStyle = BorderStyle.FixedSingle;
                flowLayoutPanel1.Controls.Add(newComp);
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
            flowLayoutPanel1.AutoScrollPosition = new System.Drawing.Point(0, scrollValue);
        }
    }
}
