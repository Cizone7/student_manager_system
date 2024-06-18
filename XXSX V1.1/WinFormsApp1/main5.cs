using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace WinFormsApp1
{
    public partial class main5 : Form
    {
        public main5()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            main2 m2 = new main2();
            m2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String StuID = textBox1.Text.Trim();//读取文本框的值
            String StuName = textBox2.Text.Trim();
            String StuSex = textBox3.Text.Trim();
            String StuSdept = comboBox1.Text.Trim();
            String StuScoll = comboBox2.Text.Trim();
            String StuClass = textBox4.Text.Trim();
            if (StuID == ""|| StuName == ""|| StuSex == ""||StuSdept==""||StuScoll==""||StuClass=="")
            {
                MessageBox.Show("信息不完整!");
                return;
            }
            if (StuSex!="男"&&StuSex!="女")
            {
                MessageBox.Show("性别错误!");
                return;
            }
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(StuClass);         

            foreach (byte c in bytestr)                   
            {
                if (c < 48 || c > 57)                          
                {
                    MessageBox.Show("班级格式错误！\n格式:2101（年份+班级号）");
                    return;
                }
            }
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string insertStr = "INSERT INTO  Student (Sno,Sname,Sex)" +
                    "VALUES ('" + StuID + "','" + StuName + "','" + StuSex  + "');"+
                    "INSERT INTO  Ognaz (Sno,Scollege,Sdept,Sclass)" +
                    "VALUES ('" + StuID + "','" + StuScoll + "','" + StuSdept + "','" + StuClass+"')"; 
                SqlCommand cmd = new SqlCommand(insertStr, conn);//通过sql语句对表添加数值
                cmd.ExecuteNonQuery();
                int str =int.Parse(StuID.Substring(0, 2))+2000;

                DateTime now = DateTime.Now;
                int y = int.Parse(StuClass.Substring(0, 2))+2000;
                if (now.Year - str > 4)
                {
                    string insertStr3 = "INSERT INTO StatusM(Sno,Sstatus)"+
                       " VALUES('"+StuID+"','毕业')";
                    SqlCommand cmd3 = new SqlCommand(insertStr3, conn);
                    cmd3.ExecuteNonQuery();
                    
                }
                else if(str < y)
                {
                    string insertStr2 = "INSERT INTO StatusM(Sno,Sstatus)" +
                       " VALUES('" + StuID + "','留级')";
                    SqlCommand cmd2 = new SqlCommand(insertStr2, conn);
                    cmd2.ExecuteNonQuery();
                    
                }
                else
                {
                    string insertStr1 = "INSERT INTO StatusM(Sno,Sstatus)" +
                       " VALUES('" + StuID + "','正常')";
                    SqlCommand cmd1 = new SqlCommand(insertStr1, conn);
                    cmd1.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("输入数据违反要求!");
                return;
            }
            finally
            {
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox4.Text = "";

            }
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SELECT Student.Sno,Student.Sname,Student.Sex,Ognaz.Scollege,Ognaz.Sdept,Ognaz.Sclass " +
                "FROM Student,Ognaz WHERE Student.Sno = Ognaz.Sno", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
        }

        private void main5_Load(object sender, EventArgs e)
        {
            this.comboBox2.Items.Add("计算机学院");
            this.comboBox2.Items.Add("信电学院");
            this.comboBox1.Items.Add("计算机科学");
            this.comboBox1.Items.Add("软件工程");
            this.comboBox1.Items.Add("信息安全");
            this.comboBox1.Items.Add("信电");
            
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SELECT Student.Sno,Student.Sname,Student.Sex,Ognaz.Scollege,Ognaz.Sdept,Ognaz.Sclass " +
                "FROM Student,Ognaz WHERE Student.Sno = Ognaz.Sno", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0];//显示查询后的数据
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
                string delete_by_id = "delete from SC where Sno=" + select_id;//sql删除语句
                SqlCommand cmd = new SqlCommand(delete_by_id, conn);
                cmd.ExecuteNonQuery();
                delete_by_id = "delete from Ognaz where Sno=" + select_id;
                cmd = new SqlCommand(delete_by_id, conn);
                cmd.ExecuteNonQuery();
                delete_by_id = "delete from Student where Sno=" + select_id;
                cmd = new SqlCommand(delete_by_id, conn);
                cmd.ExecuteNonQuery();
                delete_by_id = "delete from StudentUser where ID=" + select_id;
                cmd = new SqlCommand(delete_by_id, conn);
                cmd.ExecuteNonQuery();
                delete_by_id = "delete from StatusM where Sno=" + select_id;
                cmd = new SqlCommand(delete_by_id, conn);
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
            SqlDataAdapter dap = new SqlDataAdapter("SELECT Student.Sno,Student.Sname,Student.Sex,Ognaz.Scollege,Ognaz.Sdept,Ognaz.Sclass " +
                "FROM Student,Ognaz WHERE Student.Sno = Ognaz.Sno", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String StuID = textBox1.Text.Trim();
            String StuName = textBox2.Text.Trim();
            String StuSdept = comboBox1.Text.Trim();
            String StuScoll = comboBox2.Text.Trim();
            String StuClass = textBox4.Text.Trim();
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(StuClass);

            foreach (byte c in bytestr)
            {
                if (c < 48 || c > 57)
                {
                    MessageBox.Show("班级格式错误！\n格式:2101（年份+班级号）");
                    return;
                }
            }
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                if( StuName!="")
                {
                    string insertStr = "UPDATE Student SET Sname = '" + StuName +"' WHERE Sno = '" + StuID + "'";
                    SqlCommand cmd = new SqlCommand(insertStr, conn);
                    cmd.ExecuteNonQuery();
                }
               
                if(StuSdept!=""&&StuScoll != ""&&StuClass!="")
                {
                    int clas = int.Parse(StuClass.Substring(0, 2));
                    int id = int.Parse(StuID.Substring(0, 2));
                    if (id < clas)
                    {
                        string insert= "UPDATE StatusM SET Sstatus = '降转' WHERE Sno ='"+StuID +"'";
                        SqlCommand cmd1 = new SqlCommand(insert, conn);
                        cmd1.ExecuteNonQuery();
                    }
                    else
                    {
                        string insert1 = "UPDATE StatusM SET Sstatus = '转专业' WHERE Sno = '"+StuID+"'";
                        SqlCommand cmd2 = new SqlCommand(insert1, conn);
                        cmd2.ExecuteNonQuery();
                    }
                    string insertStr = "UPDATE Ognaz SET SCollege = '" + StuScoll + "' WHERE Sno = '" + StuID + "'";
                    SqlCommand cmd = new SqlCommand(insertStr, conn);
                    cmd.ExecuteNonQuery();
                    insertStr = "UPDATE Ognaz SET Sdept = '" + StuSdept + "' WHERE Sno = '" + StuID + "'";
                    cmd = new SqlCommand(insertStr, conn);
                    cmd.ExecuteNonQuery();
                    insertStr = "UPDATE Ognaz SET Sclass= '" + StuClass + "' WHERE Sno = '" + StuID + "'";
                    cmd = new SqlCommand(insertStr, conn);
                    cmd.ExecuteNonQuery();
                }
                else if(StuSdept != ""&& StuClass != "")
                {
                    string insertStr1 = "UPDATE StatusM SET Sstatus = '转专业' WHERE Sno='" + StuID + "'";
                    SqlCommand cmd1 = new SqlCommand(insertStr1, conn);
                    cmd1.ExecuteNonQuery();
                    string insertStr2= "UPDATE Ognaz SET Sdept = '" + StuSdept + "' WHERE Sno = '" + StuID + "'";
                    SqlCommand cmd2 = new SqlCommand(insertStr2, conn);
                    cmd2.ExecuteNonQuery();
                    string insertStr3 = "UPDATE Ognaz SET Sclass = '" + StuClass + "' WHERE Sno = '" + StuID + "'";
                    SqlCommand cmd3 = new SqlCommand(insertStr3, conn);
                    cmd3.ExecuteNonQuery();
                }
                else if (StuClass != "")
                {
                    
                    string insertStr3 = "UPDATE Ognaz SET Sclass = '" + StuClass + "' WHERE Sno = '" + StuID + "'";
                    SqlCommand cmd3 = new SqlCommand(insertStr3, conn);
                    cmd3.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("输入数据不完整！");
                    return;
                }
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
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox4.Text = "";
            }
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SELECT Student.Sno,Student.Sname,Student.Sex,Ognaz.Scollege,Ognaz.Sdept,Ognaz.Sclass " +
                "FROM Student,Ognaz WHERE Student.Sno = Ognaz.Sno", conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String StuID = textBox1.Text.Trim();
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            
            SqlConnection conn = new SqlConnection(connString);
            if(StuID == "")
            {
                conn.Open();
                SqlDataAdapter dap = new SqlDataAdapter("SELECT Student.Sno,Student.Sname,Student.Sex,Ognaz.Scollege,Ognaz.Sdept,Ognaz.Sclass " +
                "FROM Student,Ognaz WHERE Student.Sno = Ognaz.Sno", conn);//查询
                DataSet ds = new DataSet();//创建DataSet对象
                dap.Fill(ds);//填充DataSet数据集
                dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
                conn.Close();
            }
            try
            {
                conn.Open();
                String select_by_id = "SELECT Student.Sno,Student.Sname,Student.Sex,Ognaz.Scollege,Ognaz.Sdept,Ognaz.Sclass " +
                "FROM Student, Ognaz WHERE Student.Sno = Ognaz.Sno" +
                " And Student.Sno='" +StuID+"'" ;//查询
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
