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
    public partial class add_adress : Form
    {
        public add_adress()
        {
            InitializeComponent();
        }
        string connstr = global::通讯录.Properties.Settings.Default.txlmsConnectionString;
        public void refresh()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string sex = comboBox1.Text;
            string iphone = textBox3.Text;
            string home_adress = textBox4.Text;
            if (name.Equals(""))
            {
                MessageBox.Show("姓名不能为空！","提示");
            }
            else if (sex.Equals(""))
            {
                MessageBox.Show("性别不能为空！","提示");
            }
            else if (iphone.Equals(""))
            {
                MessageBox.Show("电话不能为空！", "提示");
            }
            else if (home_adress.Equals(""))
            {
                MessageBox.Show("家庭住址不能为空", "提示");
            }
            else 
            {
                
                    try
                    {
                        string sql = "insert into [txlms](name,sex,iphone,home_addr,tel_phone,off_phone)Values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','"+textBox4.Text+ "','" + textBox5.Text + "','" + textBox6.Text + "')";
                        SqlConnection conn = new SqlConnection(connstr);
                        conn.Open();
                        SqlCommand com = new SqlCommand(sql, conn);
                        int irow = com.ExecuteNonQuery();
                        if (irow == 1)
                        {
                            MessageBox.Show("添加成功", "提示");
                            refresh();
                           
                        }
                        else
                            MessageBox.Show("添加失败", "提示");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_adress_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("男");
            comboBox1.Items.Add("女");
        }
    }
    }

