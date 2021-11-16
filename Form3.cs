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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string connstr = global ::通讯录.Properties.Settings.Default.txlmsConnectionString;
        private void button2_Click(object sender, EventArgs e)
        {
            string pwd = textBox2.Text;
            if (pwd.Equals(""))
            {
                MessageBox.Show("请输入新密码！");}
                    else 
            {
                if (textBox2.Text ==textBox3.Text )
           {
               try 
               {
                   string sql = "update [user] set password='" + textBox2.Text + "'where username='" + Form1.username  + "'";
                       SqlConnection conn=new SqlConnection (connstr );
                   conn .Open ();
                   SqlCommand com=new SqlCommand (sql ,conn);
                       int irow=com.ExecuteNonQuery ();
                   if (irow >0)
                   {
                       MessageBox.Show("修改成功", "提示");
                       Close ();
                   }
                   else
                       MessageBox.Show("修改失败", "提示");

                }
               catch (Exception ex)
               {
                   MessageBox .Show (ex .Message .ToString ());
               }
           }
           else 
           {
               MessageBox.Show("两次密码不一样", "提示");
               textBox3.Text ="";
           }
        }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
    }



