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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string sq1 = "select *from [user] where username='" + comboBox1.Text + "'and password='" + textBox1.Text + "'";
            SqlConnection conn = userTableAdapter.Connection;
            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sq1, conn);
            da.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Form1. username = comboBox1.Text;
                MessageBox.Show("切换成功", "提示");
                this.Hide();
            }
            else
            {
                MessageBox.Show("切换失败", "提示");
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“txlmsDataSet3.user”中。您可以根据需要移动或删除它。
            this.userTableAdapter.Fill(this.txlmsDataSet3.user);
        }
    }
}
