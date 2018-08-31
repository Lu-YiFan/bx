namespace bx
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.web = new System.Windows.Forms.WebBrowser();
            this.rout = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.bxinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bxinfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "广西政采(20)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // web
            // 
            this.web.Location = new System.Drawing.Point(12, 474);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.ScriptErrorsSuppressed = true;
            this.web.Size = new System.Drawing.Size(365, 72);
            this.web.TabIndex = 1;
            // 
            // rout
            // 
            this.rout.Location = new System.Drawing.Point(383, 474);
            this.rout.Name = "rout";
            this.rout.Size = new System.Drawing.Size(142, 72);
            this.rout.TabIndex = 2;
            this.rout.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "监视窗口（有显示即正常）";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(641, 274);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 78);
            this.button4.TabIndex = 10;
            this.button4.Text = "手动写入数据库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // bxinfoBindingSource
            // 
            this.bxinfoBindingSource.DataMember = "bxinfo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(559, 274);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 21);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "test-name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(559, 301);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 21);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "test-url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "time";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 16;
            this.button2.Text = "湖南工院（30）";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(541, 514);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 32);
            this.button3.TabIndex = 17;
            this.button3.Text = "获取网页源码";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(541, 487);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(206, 21);
            this.textBox3.TabIndex = 18;
            this.textBox3.Text = "络捷斯特";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 274);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(533, 166);
            this.dataGridView1.TabIndex = 19;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(559, 368);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 33);
            this.button5.TabIndex = 20;
            this.button5.Text = "刷新数据库";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(539, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "不可描述小工具（乱点会爆掉的呢）";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(559, 407);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(182, 32);
            this.button6.TabIndex = 22;
            this.button6.Text = "打开数据库目录【bx.mdb】";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(127, 148);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(103, 32);
            this.button7.TabIndex = 23;
            this.button7.Text = "湖南商学院(20)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "已采集信息：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(559, 331);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(75, 21);
            this.textBox4.TabIndex = 25;
            this.textBox4.Text = "test-time";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(236, 148);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(115, 33);
            this.button8.TabIndex = 26;
            this.button8.Text = "湖南现代物流(15)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(125, 107);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(103, 33);
            this.button9.TabIndex = 27;
            this.button9.Text = "民大相思湖(7)";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(645, 515);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(102, 31);
            this.button10.TabIndex = 31;
            this.button10.Text = "软件著作权查询";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(641, 368);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 32);
            this.button11.TabIndex = 33;
            this.button11.Text = "初始化数据库";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(12, 185);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(127, 34);
            this.button12.TabIndex = 34;
            this.button12.Text = "江苏海事职院（14）";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(62, 28);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(106, 43);
            this.button13.TabIndex = 35;
            this.button13.Text = "开启自动监控";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(174, 28);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(115, 43);
            this.button14.TabIndex = 36;
            this.button14.Text = "关闭自动监控";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "Info：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(350, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "未知";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(366, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 39;
            this.label10.Text = "0";
            // 
            // timer3
            // 
            this.timer3.Interval = 1800000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "run";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(11, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(44, 43);
            this.panel1.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 42;
            this.label6.Text = "自动化：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 43;
            this.label7.Text = "手动：";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(158, 190);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(123, 28);
            this.button15.TabIndex = 44;
            this.button15.Text = "贵州装备制造（10）";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "已经运行";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(287, 191);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(110, 28);
            this.button16.TabIndex = 46;
            this.button16.Text = "四川政采（25）";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 554);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rout);
            this.Controls.Add(this.web);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "【抓标讯】GUI后台工具V1.3---记得改备注";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bxinfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.RichTextBox rout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
       // private bxDataSet2 bxDataSet2;
        private System.Windows.Forms.BindingSource bxinfoBindingSource;
     //   private bxDataSet2TableAdapters.bxinfoTableAdapter bxinfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button16;
    }
}

