using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WinFormsApp1
{
    public partial class awards : Form
    {
        public awards()
        {
            InitializeComponent();
        }

        private void awards_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("计算机学院");
            this.comboBox1.Items.Add("信电学院");
            this.comboBox2.Items.Add("计算机科学");
            this.comboBox2.Items.Add("软件工程");
            this.comboBox2.Items.Add("信息安全");
            this.comboBox2.Items.Add("信电");
            this.comboBox3.Items.Add("22");
            this.comboBox3.Items.Add("21");
            this.comboBox3.Items.Add("20");
            this.comboBox3.Items.Add("19");
            this.comboBox4.Items.Add("一等奖");
            this.comboBox4.Items.Add("二等奖");
            this.comboBox4.Items.Add("三等奖");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            main2 m = new main2();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string StuCol = comboBox1.Text.Trim();
            string Studept = comboBox2.Text.Trim();
            int Stuy =int.Parse( comboBox3.Text.Trim().Substring(0,2));
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SELECT SC.Sno AS Sno,Sname AS Sname,AVG(SC.Grade) AS avg " +
                "FROM SC, Student WHERE SC.Sno IN(SELECT SC.Sno FROM Ognaz where Scollege = '"+ StuCol+"' AND Sdept = '"+ Studept +"' " +
                "AND  SC.Sno = Ognaz.Sno)and SC.Sno = Student.Sno AND SC.Sno LIKE '"+Stuy+"%' " +
                "GROUP BY Sname, SC.Sno  ", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0];//显示查询后的数据
            SqlDataAdapter dap1 = new SqlDataAdapter("SELECT  Award.Sno AS Sno,Student.Sname AS Sname,Award.INFOR AS Award " +
                "FROM Award,Student WHERE Award.Sno IN(SELECT Award.Sno FROM Ognaz where Scollege = '" + StuCol + "' AND Sdept = '" + Studept + "' " +
                "AND  Award.Sno = Ognaz.Sno)and Award.Sno = Student.Sno AND Award.Sno LIKE '" + Stuy + "%' " 
                , conn);//查询
            DataSet ds1 = new DataSet();//创建DataSet对象
            dap1.Fill(ds1);//填充DataSet数据集
            dataGridView2.DataSource = ds1.Tables[0];//显示查询后的数据
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sno = textBox1.Text.Trim();
            string award = comboBox4.Text.Trim();
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(sno);
            
            foreach (byte c in bytestr)
            {
                if (c < 48 || c > 57)
                {
                    MessageBox.Show("学号输入错误！");
                    return;
                }
            }
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string insertStr = "INSERT INTO Award(Sno, INFOR) VALUES('" + sno + "','" + award + "')";
            SqlCommand cmd = new SqlCommand(insertStr, conn);//通过sql语句对表添加数值
            cmd.ExecuteNonQuery();
            string StuCol = comboBox1.Text.Trim();
            string Studept = comboBox2.Text.Trim();
            int Stuy = int.Parse(comboBox3.Text.Trim().Substring(0, 2));
            SqlDataAdapter dap1 = new SqlDataAdapter("SELECT Award.Sno AS Sno,Student.Sname AS Sname,Award.INFOR AS Award " +
                "FROM Award,Student WHERE Award.Sno IN(SELECT Award.Sno FROM Ognaz where Scollege = '" + StuCol + "' AND Sdept = '" + Studept + "' " +
                "AND  Award.Sno = Ognaz.Sno)and Award.Sno = Student.Sno AND Award.Sno LIKE '" + Stuy + "%' "
                , conn);//查询
            DataSet ds1 = new DataSet();//创建DataSet对象
            dap1.Fill(ds1);//填充DataSet数据集
            dataGridView2.DataSource = ds1.Tables[0];//显示查询后的数据
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string select_id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是ID
                string delete_by_id = "delete from Award where Sno=" + select_id;//sql删除语句
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
            string StuCol = comboBox1.Text.Trim();
            string Studept = comboBox2.Text.Trim();
            int Stuy = int.Parse(comboBox3.Text.Trim().Substring(0, 2));
            SqlDataAdapter dap1 = new SqlDataAdapter("SELECT Award.Sno AS Sno,Student.Sname AS Sname,Award.INFOR AS Award " +
                "FROM Award,Student WHERE Award.Sno IN(SELECT Award.Sno FROM Ognaz where Scollege = '" + StuCol + "' AND Sdept = '" + Studept + "' " +
                "AND  Award.Sno = Ognaz.Sno)and Award.Sno = Student.Sno AND Award.Sno LIKE '" + Stuy + "%' "
                , conn);//查询
            DataSet ds1 = new DataSet();//创建DataSet对象
            dap1.Fill(ds1);//填充DataSet数据集
            dataGridView2.DataSource = ds1.Tables[0];//显示查询后的数据
            conn.Close();
        }
    }
}
