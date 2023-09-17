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

namespace ProjectSRJ.Windows.MK2Features
{
    public partial class PostView : MasterView
    {
        MainForm_MK2 ParentForm;
        public PostView(MainForm_MK2 parent)
        {
            InitializeComponent();
            ParentForm = parent;
        }
    }
}
