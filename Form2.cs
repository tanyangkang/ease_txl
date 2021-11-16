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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        string connstr = global ::通讯录.Properties.Settings.Default.txlmsConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pwd = textBox2.Text;
            if (name.Equals(""))
            {
                MessageBox.Show("用户名不能为空");
            }
            else if (pwd.Equals(""))
            {
                MessageBox.Show("密码不能为空");
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    try
                    {
                        string sql = "insert into [user](username,password,memo)Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                        SqlConnection conn = new SqlConnection(connstr);
                        conn.Open();
                        SqlCommand com = new SqlCommand(sql, conn);
                        int irow = com.ExecuteNonQuery();
                        if (irow == 1)
                        {
                            MessageBox.Show("添加成功", "提示");
                            Close();
                        }
                        else
                            MessageBox.Show("添加失败", "提示");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("两次密码不一样", "提示");
                    textBox3.Text = "";
                }
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
