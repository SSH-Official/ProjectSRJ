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

namespace ProjectSRJ.Windows
{
    public partial class MyPartyForm : Form
    {
        public MyPartyForm()
        {
            InitializeComponent();
        }

        FindPartyForm ParentForm;

        public MyPartyForm(FindPartyForm parent): this()
        {
            this.ParentForm = parent;
            timer_addon.Enabled = true;
            AdjustLocation();
        }

        private void timer_addon_Tick(object sender, EventArgs e)
        {
            AdjustLocation();            
        }

        private void AdjustLocation()
        {
            if (ParentForm != null && ParentForm.isDragging)
            {
                Point newLocation = new Point(ParentForm.Location.X + ParentForm.Width + 0, ParentForm.Location.Y);
                this.Location = newLocation;
            }            
        }
    }
}
