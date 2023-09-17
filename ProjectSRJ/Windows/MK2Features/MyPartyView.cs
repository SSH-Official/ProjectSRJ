﻿using Lib.Frame;
using ProjectSRJ.Windows.Main;
using ProjectSRJ.Windows.MK2Features;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSRJ.Windows.MK2Views
{
    public partial class MyPartyView : MasterView
    {
        MainForm_MK2 ParentForm;
        public MyPartyView(MainForm_MK2 parent)
        {
            InitializeComponent();
            ParentForm = parent;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            ParentForm.ShowView<PostView>();
        }
    }
}
