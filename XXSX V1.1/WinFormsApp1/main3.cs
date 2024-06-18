using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    
    public partial class main3 : Form
    {
        public main3()
        {
            InitializeComponent();
        }
        private void RefreshTable()
        {

        }
        private void main3_Load(object sender, EventArgs e)
        {
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("select SC.Sno,SC.Cno ,Course.Cname,SC.Grade from SC,Course WHERE SC.Cno=Course.Cno", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String sno = textBox1.Text.Trim();
            String cno = textBox2.Text.Trim();
            int gra = 0;
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入成绩!");
                return;
            }
            else
            {
               gra= int.Parse(textBox3.Text.Trim());
            }
           
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string insertStr = "INSERT INTO  SC (Sno,Cno,Grade)    " +
                    "VALUES ('" + sno + "','" + cno + "','" + gra + "')";
                SqlCommand cmd = new SqlCommand(insertStr, conn);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
            }
            finally
            {
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("select SC.Sno,SC.Cno ,Course.Cname,SC.Grade from SC,Course WHERE SC.Cno=Course.Cno", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string select_cno = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string delete_by_id = "delete from SC where Sno=" + select_id+"and Cno =" + select_cno;//sql删除语句
                SqlCommand cmd = new SqlCommand(delete_by_id, conn);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("请正确选择行!");
            }
            finally
            {
                conn.Close();
            }
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("select SC.Sno,SC.Cno ,Course.Cname,SC.Grade from SC,Course WHERE SC.Cno=Course.Cno", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String sno = textBox1.Text.Trim();
            String cno = textBox2.Text.Trim();
            int gra = int.Parse(textBox3.Text.Trim());
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string insertStr = "UPDATE SC SET Grade='" + gra + "' WHERE Sno = '" + sno + "' AND Cno = '" + cno + "'";
                SqlCommand cmd = new SqlCommand(insertStr, conn);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
            }
            finally
            {
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("select SC.Sno,SC.Cno ,Course.Cname,SC.Grade from SC,Course WHERE SC.Cno=Course.Cno", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            String sno = textBox1.Text.Trim();
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            if(sno == "")
            {
                conn.Open();
                SqlDataAdapter dap = new SqlDataAdapter("select SC.Sno,SC.Cno ,Course.Cname,SC.Grade from SC,Course WHERE SC.Cno=Course.Cno", conn);//查询
                DataSet ds = new DataSet();//创建DataSet对象
                dap.Fill(ds);//填充DataSet数据集
                dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
                conn.Close();
                return;
            }
            try
            {
                conn.Open();
                String select_by_id = "select SC.Sno,SC.Cno ,Course.Cname,SC.Grade from SC,Course WHERE SC.Cno=Course.Cno AND Sno='" + sno + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
            }
            catch
            {
                MessageBox.Show("查询语句有误，请认真检查SQL语句!");
            }
            finally
            {
                conn.Close();
                textBox1.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            main2 m2 = new main2();
            m2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            m2 m2 = new m2();
            m2.Show();
        }
    }
}
