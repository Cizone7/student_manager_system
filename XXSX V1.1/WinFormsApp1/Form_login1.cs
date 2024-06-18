using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_login1 : Form
    {
        Form1 _form1;
        public Form_login1(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }
        
        private void Form_Login1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public string code; //验证码
        private void button1_Click(object sender, EventArgs e) //登入
        {
            string username = textBox1.Text.Trim();
            string password = EncryptWithMD5(textBox2.Text.Trim());
            string connectString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectString);
            sqlConnection.Open();

            string sql = "select ID,PassWord from StudentUser where ID = '" + username + "' and PassWord = '" + password + "'";
            SqlCommand sqlcommand = new SqlCommand(sql, sqlConnection);

            SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();//读取数据
            if (sqlDataReader.HasRows && textBox3.Text == code)
            {
                MessageBox.Show("欢迎使用！");
                main1 mn1 = new main1();
                mn1.GetID(username);
                mn1.Show();
                this.Hide();
            }
            else if(sqlDataReader.HasRows && textBox3.Text != code)
            {
                MessageBox.Show("验证码错误，登入失败！");
                return;
            }
            else
            {
                MessageBox.Show("账号密码有误，登入失败！");
                return;
            }
            sqlDataReader.Close();
            sql = "INSERT INTO SysLog1(UserID,dentity,DateAndTime,UserOperation) "+
                "VALUES( '" + username + "' , 'Student','" + DateTime.Now + "' , '" + "Login" + "')";
            sqlcommand = new SqlCommand(sql, sqlConnection);
            sqlcommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        private string EncryptWithMD5(string source)//MD5加密
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
            }
            return strbul.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            _form1.Show();
        }

        private void Form_login1_Load(object sender, EventArgs e)
        {
            Random ran = new Random();
            int number;
            char code1;
            for (int i = 0; i < 5; i++)
            {
                number = ran.Next();
                if (number % 2 == 0)
                    code1 = (char)('0' + (char)(number % 10));
                else
                    code1 = (char)('A' + (char)(number % 26));
                this.code += code1.ToString();
            }
            label5.Text = code;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
        private void Form_login1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
