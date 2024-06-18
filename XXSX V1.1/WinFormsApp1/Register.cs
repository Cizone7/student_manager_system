using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()!=""&&textBox2.Text.Trim()!=""&&comboBox1.Text.Trim()!=""&&
                textBox3.Text.Trim() != "")
            {
                try
                {
                    string conString = "Server = LAPTOP-3JH5U78I;Initial Catalog=xsxx;Integrated Security=true";
                    SqlConnection connection = new SqlConnection(conString);
                    string username = textBox1.Text.Trim();
                    string sex = comboBox1.Text.Trim();
                    connection.Open();
                    string sql1 = "select Sno,Sex from Student where Sno ='" + username + "' and  Sex = '" +
                        sex + "'";
                    SqlCommand sqlcommand1 = new SqlCommand(sql1, connection);
                    SqlDataReader sqlDataReader1 = sqlcommand1.ExecuteReader();
                    bool a = sqlDataReader1.HasRows;
                    sqlDataReader1.Close();
                    if (a)
                    {
                        string sql2 = "select ID from StudentUser where ID = '" + username + "'";
                        SqlCommand sqlCommand2 = new SqlCommand(sql2, connection);
                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                        if (!sqlDataReader2.HasRows)
                        {
                            string sql3 = "insert into StudentUser (ID, PassWord, Sex, UserMobile, StudentBirthday, UserPhoto)" +
                                "values(@userid, @userpassword,@sex,@usermobile,@StudentBirthday,@userphoto)";
                            SqlCommand command = new SqlCommand(sql3, connection);
                            SqlParameter sqlParameter = new SqlParameter("@userid", textBox1.Text);
                            command.Parameters.Add(sqlParameter);
                            sqlParameter = new SqlParameter("@userpassword", EncryptWithMD5(textBox2.Text));
                            command.Parameters.Add(sqlParameter);
                            sqlParameter = new SqlParameter("@sex", comboBox1.Text);
                            command.Parameters.Add(sqlParameter);
                            sqlParameter = new SqlParameter("@usermobile", textBox3.Text);
                            command.Parameters.Add(sqlParameter);
                            sqlParameter = new SqlParameter("@StudentBirthday", dateTimePicker1.Value);
                            command.Parameters.Add(sqlParameter);
                            sqlParameter = new SqlParameter("@userphoto", SqlDbType.VarBinary, mybyte.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, mybyte);
                            command.Parameters.Add(sqlParameter);
                            sqlDataReader2.Close();
                            //打开数据库连接

                            command.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("注册成功");
                         }
                        else
                        {
                            MessageBox.Show("该用户已注册。");
                        }
                    }
                    else
                    {
                        MessageBox.Show("我校无该学员");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请将信息填写完整！");
            }
        }
        public Byte[] mybyte = new byte[0];
        public static string EncryptWithMD5(string source)
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
        private void textBox2_Leave(object sender, EventArgs e)//校验密码格式
        {
            if (textBox1.Text.Trim() != "")
            {
                //使用regex（正则表达式）进行格式设置 至少有数字、大写字母、小写字母各一个。最少3个字符、最长20个字符。
                Regex regex = new Regex(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{3,20}");

                if (regex.IsMatch(textBox2.Text))//判断格式是否符合要求
                {
                    //MessageBox.Show("输入密码格式正确!");
                }
                else
                {
                    MessageBox.Show("至少有数字、大写字母、小写字母各一个。最少3个字符、最长20个字符！");
                    textBox2.Focus();
                }
            }
            else
            {
                MessageBox.Show("请填写密码！");
            }
        }
        private void Register_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("男");
            this.comboBox1.Items.Add("女");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //打开浏览图片对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string picturePath = openFileDialog.FileName;//获取图片路径
                                                         //文件的名称，每次必须更换图片的名称，这里很为不便
                                                         //创建FileStream对象
            FileStream fs = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
            //声明Byte数组
            mybyte = new byte[fs.Length];
            //读取数据
            fs.Read(mybyte, 0, mybyte.Length);
            pictureBox1.Image = Image.FromStream(fs);
            fs.Close();
        }
    }
}
