﻿namespace WinFormsApp1
{
    partial class main2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "查看登入日志";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(158, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "学生信息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(158, 294);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 47);
            this.button3.TabIndex = 2;
            this.button3.Text = "课程信息";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(158, 475);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 47);
            this.button4.TabIndex = 3;
            this.button4.Text = "学生成绩";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(158, 588);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 47);
            this.button5.TabIndex = 4;
            this.button5.Text = "退出系统";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(158, 383);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(155, 50);
            this.button6.TabIndex = 5;
            this.button6.Text = "评奖评优";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // main2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 779);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "main2";
            this.Text = "main2";
            this.Load += new System.EventHandler(this.main2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}