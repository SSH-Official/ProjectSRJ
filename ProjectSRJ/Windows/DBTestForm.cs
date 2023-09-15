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
    public partial class DBTestForm : Form
    {
        public DBTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBManager_Functional DBm = new DBManager_Functional();
            List<Member> members;
            if (DBm.TryGetMemberList(out members) == false)
            {
                MessageBox.Show("?");
                return;
            }

            string strResult = string.Empty;
            foreach (Member m in members)
            {
                Console.WriteLine(m);
                strResult += m + "\r\n";
            }

            dataGridView1.DataSource = members;
            
            textBox1.Text= strResult;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
