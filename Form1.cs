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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“txlmsDataSet.txlms”中。您可以根据需要移动或删除它。
            this.txlmsTableAdapter.Fill(this.txlmsDataSet.txlms);
            // TODO: 这行代码将数据加载到表“txlmsDataSet.user”中。您可以根据需要移动或删除它。
            this.userTableAdapter.Fill(this.txlmsDataSet.user);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string username;
        private void button1_Click(object sender, EventArgs e)
        {

            string sq1 = "select *from [user] where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
            SqlConnection conn = userTableAdapter.Connection;
            DataSet ds1 = new DataSet();
            SqlDataAdapter da=new SqlDataAdapter(sq1,conn);
            da.Fill(ds1);
            if (ds1.Tables[0].Rows.Count >0)
            {
                username = textBox1.Text;
                MDIParent1 mdp = new MDIParent1();
                mdp.Show();
           // MessageBox.Show("登录成功","提示");
                this.Hide ();
            }
            else
            {
                MessageBox.Show("账号或密码错误！", "提示");
                textBox1.Focus();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm3 = new Form2();
            frm3.ShowDialog();
        }


    }
}
