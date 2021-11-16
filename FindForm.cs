using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 通讯录
{
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
        }

        private void FindForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“txlmsDataSet4.txlms”中。您可以根据需要移动或删除它。
            this.txlmsTableAdapter1.Fill(this.txlmsDataSet4.txlms);
            // TODO: 这行代码将数据加载到表“txlmsDataSet2.txlms”中。您可以根据需要移动或删除它。
            //this.txlmsTableAdapter.Fill(this.txlmsDataSet2.txlms);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sq1 = "select *from txlms where name='" + this.toolStripTextBox1.Text+ "'";
            SqlConnection conn = this.txlmsTableAdapter.Connection;
            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sq1, conn);
            da.Fill(ds1,"abc");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                
                this.dataGridView1.DataSource = ds1;
                this.dataGridView1.DataMember = "abc";
                dataGridView1.Refresh();
            }
            else
            {
                toolStripTextBox1.Text = "";
                MessageBox.Show("没有找到该联系人，请重试！", "提示");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string sq1 = "select *from txlms where iphone ='" + this.toolStripTextBox2.Text + "'";
            SqlConnection conn = this.txlmsTableAdapter.Connection;
            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sq1, conn);
            da.Fill(ds1, "123");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                
                this.dataGridView1.DataSource = ds1;
                this.dataGridView1.DataMember = "123";
                dataGridView1.Refresh();
            }
            else
            {
                toolStripTextBox2.Text = "";
                MessageBox.Show("没有找到该联系人，请重试！", "提示");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string sq1 = "select *from txlms where name like '%" + this.toolStripTextBox3.Text + "%' or iphone like '%" + this.toolStripTextBox3.Text + "%' or tel_phone like '%" + this.toolStripTextBox3.Text + "%' or off_phone like '%" + this.toolStripTextBox3.Text + "%' or home_addr like '%" + this.toolStripTextBox3.Text + "%' or office_addr like'%" + this.toolStripTextBox3.Text + "%'";
            SqlConnection conn = this.txlmsTableAdapter.Connection;
            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sq1, conn);
            da.Fill(ds1, "123");
            if (ds1.Tables[0].Rows.Count > 0)
            {

                this.dataGridView1.DataSource = ds1;
                this.dataGridView1.DataMember = "123";
                dataGridView1.Refresh();
            }
            else
            {
                toolStripTextBox2.Text = "";
                MessageBox.Show("没有找到该联系人，请重试！", "提示");
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
