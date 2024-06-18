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

namespace WinFormsApp1
{
    public partial class main7 : Form
    {
        public main7()
        {
            InitializeComponent();
        }

        private void main7_Load(object sender, EventArgs e)
        {
            String connString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("select * from SysLog1" , conn);//查询
            DataSet ds = new DataSet();//创建DataSet对象
            dap.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;//显示查询后的数据
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            main2 m2 = new main2();
            m2.Show();
        }
    }
}
