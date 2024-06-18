using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class main1 : Form
    {
        public main1()
        {
            InitializeComponent();
        }
        string ID;
        public void GetID(string id)
        {
            label8.Text = id;
            label8.Refresh();
            ID = id;
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void main1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void main1_Load(object sender, EventArgs e)
        {
            
            string name, sex, dept, tel,status;
            int age;
            DateTime sage;
            DateTime now = DateTime.Now;
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Student where Sno = '" + ID + "';select * from StudentUser where ID ='" + ID + "';select * from Ognaz Where Sno ='"+ID+
                "';select * from StatusM where Sno = '"+ID +"'";
            SqlDataReader reader = cmd.ExecuteReader();

            //从reader中读取下一行数据,如果没有数据,reader.Read()返回flase  
            while (reader.Read())
            {
                name = reader.GetString(reader.GetOrdinal("Sname"));
               

                label9.Text = name;
                label9.Refresh();
                
                break;
            }
            reader.NextResult();
            while (reader.Read())
            {
                sex = reader.GetString(reader.GetOrdinal("Sex"));
                sage = reader.GetDateTime(reader.GetOrdinal("StudentBirthday"));
                age = now.Year - sage.Year;
                tel = reader.GetString(reader.GetOrdinal("UserMobile"));
                label10.Text = sex;
                label11.Text = age.ToString();
                label13.Text = tel;
                break;
            }
            reader.NextResult();
            while (reader.Read())
            {

                dept = reader.GetString(reader.GetOrdinal("Sdept"));
                label12.Text = dept;
                break;
            }
            reader.NextResult();
            while (reader.Read())
            {

                status = reader.GetString(reader.GetOrdinal("Sstatus"));
                label21.Text = status;
                break;
            }
            reader.Close();
            SqlDataAdapter dap = new SqlDataAdapter("select * from SC where Sno='" + ID + "'", conn);//查询'
            SqlDataAdapter dap2 = new SqlDataAdapter("select * from Course", conn);
            DataSet ds = new DataSet();//创建DataSet对象
            DataSet ds2 = new DataSet();
            dap.Fill(ds);//填充DataSet数据集
            dap2.Fill(ds2);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            dataGridView2.DataSource = ds2.Tables[0].DefaultView;
            conn.Close();

            int i = 0;
            int x = 0, h = 0;
            int a;
            for (; i < ds.Tables[0].Rows.Count; i++)//读取DataSet中的指定数据
            {
                x += int.Parse(ds.Tables[0].Rows[i][2].ToString());
                if (int.Parse(ds.Tables[0].Rows[i][2].ToString()) > 59)
                    h++;
            }
            a = x / i;
            label17.Text = h.ToString();
            label19.Text = a.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                string sql = "select UserPhoto from StudentUser where ID = '" + ID + "'";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "StudentUser");
              
                int c = dataSet.Tables["StudentUser"].Rows.Count;
                if (c > 0)
                {
                    Byte[] mybyte = new byte[0];
                    mybyte = (Byte[])(dataSet.Tables["StudentUser"].Rows[c - 1]["UserPhoto"]);
                    MemoryStream ms = new MemoryStream(mybyte);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                else
                    pictureBox1.Image = null;
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Award1 m = new Award1();
            m.GetID(ID);
            m.Show();
        }
    }
}
