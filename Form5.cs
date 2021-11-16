﻿using System;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string connstr = global::通讯录.Properties.Settings.Default.txlmsConnectionString;
        public void table()
        {
            /*dataGridView1.Rows.Clear();
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string sql = "select * from [txlms]";
            SqlCommand com = new SqlCommand(sql, conn);
            int irow = com.ExecuteNonQuery();
            conn.Close();*/
            string sq1 = "select *from txlms ";
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
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("确定是否删除该联系人？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string sql = "delete from [txlms] where id='" + textBox2.Text + "'";
                        SqlConnection conn = new SqlConnection(connstr);
                        conn.Open();
                        SqlCommand com = new SqlCommand(sql, conn);
                        int irow = com.ExecuteNonQuery();
                        if (irow == 1)
                        {
                            MessageBox.Show("删除成功！", "提示");
                            table();
                    }
                        else
                            MessageBox.Show("删除失败！", "提示");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    this.Close();
                }
            
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“txlmsDataSet.txlms”中。您可以根据需要移动或删除它。
            this.txlmsTableAdapter1.Fill(this.txlmsDataSet.txlms);
            // TODO: 这行代码将数据加载到表“txlmsDataSet4.txlms”中。您可以根据需要移动或删除它。
           // this.txlmsTableAdapter.Fill(this.txlmsDataSet4.txlms);
            // TODO: 这行代码将数据加载到表“txlmsDataSet7.user”中。您可以根据需要移动或删除它。
            //this.userTableAdapter.Fill(this.txlmsDataSet7.user);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                this.textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                this.textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                this.textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                this.textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                this.textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            }
            catch
            {
                ;
                //MessageBox.Show("选择错误！");
            }
        }
    }
}

