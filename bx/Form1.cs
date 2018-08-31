using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace bx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        ///广西湖南 gxhn
        ///贵州云南 gzyn
        ///重庆西藏四川 cqxzsc
        ///江苏上海 jssh

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                web.Url = new Uri("http://www.gxgp.gov.cn/cggkzb/index.htm");
                HttpClient httpClient11 = new HttpClient();
                httpClient11.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.14955");
                HttpResponseMessage response11 = await httpClient11.GetAsync(new Uri("http://www.gxgp.gov.cn/cggkzb/index_1.htm"));
                response11.EnsureSuccessStatusCode();//确保请求成功  
                string result11 = await response11.Content.ReadAsStringAsync();
                rout.Text = result11;//输出源码到文本框
                string web_code = result11;
                MatchCollection ms1 = new Regex("(title=).*?(><span)").Matches(web_code);
                MatchCollection ms = new Regex("(http://www.gxgp.gov.cn/cggkzb/1).*?(htm)").Matches(web_code);
                MatchCollection ms2 = new Regex("(f-right\">).*?(</div>)").Matches(web_code);

                int i = 0;
                while (i < 20)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("title=\"", "");
                    name = name.Replace("\"><span", "");
                    textBox1.Text = name;

                   
                    textBox2.Text = ms[i].Value;

                    string time = ms2[i].Value;
                    time = time.Replace("f-right\">", "");
                    time = time.Replace("</div>", "");
                    textBox4.Text = time;
                    // Thread.Sleep(2000);
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + button1.Text + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                   OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象  
                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;

                }
                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                string sql1 = "select * from bxinfo";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "bxinfo");
                DataTable dt = thisDataSet.Tables["bxinfo"];
                this.dataGridView1.DataSource = dt;
                con1.Close();
                MessageBox.Show("已经写入" + button1.Text + "条数据，请查看数据库");
            }
            catch {
                MessageBox.Show("请求失败，联系小哥哥吧");
            }


        }  //广西政府采购(ok)

      

        private void Form1_Load(object sender, EventArgs e)
        {
            timer3.Enabled = false;

            timer1.Enabled = true;
            // timer2.Enabled = true;
           // this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;   默认选中行
           
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
            string sql = "select * from bxinfo";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, con);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "bxinfo");
            DataTable dt = thisDataSet.Tables["bxinfo"];
            this.dataGridView1.DataSource = dt;
            con.Close();

        }  //加载完成

        private void button4_Click_1(object sender, EventArgs e)
        {
           
            string sql = "";
            sql = "insert into [bxinfo]([name], [url], [time]) values('"+ textBox1.Text + "','" + textBox2.Text + "','" + 19960518 + "')";
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
            OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象  

            con.Open(); //打开数据库连接  
            cmd.ExecuteNonQuery(); //执行Command命令  
            con.Close(); //关闭数据库连接  

            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
            string sql1 = "select * from bxinfo";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "bxinfo");
            DataTable dt = thisDataSet.Tables["bxinfo"];
            this.dataGridView1.DataSource = dt;
            con1.Close();

            MessageBox.Show("请注意，已写入数据");
        }  //手动写入(ok)

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text =DateTime.Now.ToLocalTime().ToString();

            if (timer3.Enabled == false)
            {
                label9.Text = "未运行";
                panel1.BackColor =Color.Red;
            }
           
           
           
        }   //状态描述

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string urll = "http://www.hunangy.com/html/news/gonggao/index.html";
                web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("gb2312"));//这里设置编码
               rout.Text= html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(color=''>).*?(</font>)").Matches(web_code);
                MatchCollection ms = new Regex("(/html/news/gonggao/).*?(.html)").Matches(web_code);
                MatchCollection ms2 = new Regex("(808080\">).*?(</font>)").Matches(web_code);


                int i = 0;
               // int a = 0;
                while (i < 30)
                {
                    string name= ms1[i].Value;
                    name = name .Replace("color=''>", "");
                    name = name.Replace("</font>", "");
                    textBox1.Text = name;

                   
                    textBox2.Text = "http://www.hunangy.com" + ms[i].Value;

                    string time = ms2[i].Value;
                    time = time.Replace("808080\">", "");
                    time = time.Replace("</font>", "");
                    textBox4.Text = time;


                    // Thread.Sleep(2000);
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + button2.Text + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 
                    

            
                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                  // a = a + 2;

                   

                }
                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                string sql1 = "select * from bxinfo";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "bxinfo");
                DataTable dt = thisDataSet.Tables["bxinfo"];
                this.dataGridView1.DataSource = dt;
                con1.Close();
                MessageBox.Show("已经写入"+button2.Text+"条数据，请查看数据库");
            }
            catch
            {
                MessageBox.Show("请求失败，联系小哥哥吧");
            }
        }   //湖南工程(ok)

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox3.Text;
                web.Url = new Uri(a);
                HttpClient httpClient11 = new HttpClient();
                httpClient11.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.14955");
                HttpResponseMessage response11 = await httpClient11.GetAsync(new Uri(a));
                response11.EnsureSuccessStatusCode();//确保请求成功  
                string result11 = await response11.Content.ReadAsStringAsync();
                rout.Text = result11;//输出源码到文本框
            }
            catch {
                MessageBox.Show("乱点爆掉了吧，应该是你没加http头");
            }
           
        }  //网页源码测试(ok)

        private void timer2_Tick(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
            string sql = "select * from bxinfo";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, con);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "bxinfo");
            DataTable dt = thisDataSet.Tables["bxinfo"];
            this.dataGridView1.DataSource = dt;
            con.Close();
        }  //定时刷新数据库

        private void button6_Click(object sender, EventArgs e)
        {
            string ml = Application.StartupPath;
            System.Diagnostics.Process.Start(ml);
           // MessageBox.Show("请查看【bx.mdb】文件");
        }  //打开目录(ok)

        private void button5_Click(object sender, EventArgs e)
        {
          //  this.dataGridView1.SelectedCells[0].Value.ToString();
         //    dataGridView1.Rows.Remove(a);
            

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
            string sql = "select * from bxinfo";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, con);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "bxinfo");
            DataTable dt = thisDataSet.Tables["bxinfo"];
            this.dataGridView1.DataSource = dt;
            con.Close();
        }  //删除(bug)

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string urll = "http://www.hnuc.edu.cn/column/zbxx/index.shtml";
                web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(style=\"\">).*?(</a>)").Matches(web_code);
                MatchCollection ms = new Regex("(/column/zbxx/2).*?(.shtml)").Matches(web_code);
                MatchCollection ms2 = new Regex("(times\">)\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 20)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("style=\"\">", "");
                    name = name.Replace("</a>", "");
                    textBox1.Text = name;


                    textBox2.Text = "http://www.hnuc.edu.cn/" + ms[i].Value;

                    string time= ms2[i].Value;
                    time= time.Replace("times\">", "");
                    textBox4.Text = time;

                    // Thread.Sleep(2000);
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + button7.Text + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }
                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                string sql1 = "select * from bxinfo";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "bxinfo");
                DataTable dt = thisDataSet.Tables["bxinfo"];
                this.dataGridView1.DataSource = dt;
                con1.Close();
                MessageBox.Show("已经写入" + button7.Text + "条数据，请查看数据库");
            }
            catch
            {
                MessageBox.Show("请求失败，联系小哥哥吧");
            }
        }   //湖南商学院(ok)

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string urll = "http://www.56edu.com/list.jsp?urltype=tree.TreeTempUrl&wbtreeid=1049";
                web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(title=\").*?(style=)").Matches(web_code);
                MatchCollection ms = new Regex("(show.jsp).*?(wbnewsid=)\\d{4}").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 15)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("title=\"", "");
                    name = name.Replace("style=", "");
                    name = name.Replace("\"", "");
                    textBox1.Text = name;


                    textBox2.Text = "http://www.56edu.com/" + ms[i].Value;

                    string time = ms2[i].Value;
                   // time = time.Replace("times\">", "");
                    textBox4.Text = time;

                    // Thread.Sleep(2000);
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + button8.Text + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }
                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                string sql1 = "select * from bxinfo";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "bxinfo");
                DataTable dt = thisDataSet.Tables["bxinfo"];
                this.dataGridView1.DataSource = dt;
                con1.Close();
                MessageBox.Show("已经写入" + button8.Text + "条数据，请查看数据库");
            }
            catch
            {
                MessageBox.Show("请求失败，联系小哥哥吧");
            }
        }    //湖南现代物流（ok）

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string urll = "http://xshxy.cn/xwzx/cggg.htm";
                web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(title=\"【).*?(\">)").Matches(web_code);
                MatchCollection ms = new Regex("(/info).*?(.htm)").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                int a = 0;
                while (i < 7)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("title=", "");
                    name = name.Replace(">", "");
                    name = name.Replace("\"", "");
                  //  name = name.Replace("【", "");
                    textBox1.Text = name;

                    string url = "http://xshxy.cn" + ms[a].Value;
                    url = url.Replace("target = ","");
                    textBox2.Text = url;



                    string time = ms2[i].Value;
                    // time = time.Replace("times\">", "");
                    textBox4.Text = time;

                    // Thread.Sleep(2000);
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + button9.Text + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    a = a + 2;



                }
                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                string sql1 = "select * from bxinfo";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "bxinfo");
                DataTable dt = thisDataSet.Tables["bxinfo"];
                this.dataGridView1.DataSource = dt;
                con1.Close();
                MessageBox.Show("已经写入" + button9.Text + "条数据，请查看数据库");
            }
            catch
            {
                MessageBox.Show("请求失败，联系小哥哥吧");
            }
        }  //民大相思湖（ok）

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string urll = "http://www.publics.com.cn/c_search?key=" + textBox3.Text + "&ct=&tp=&pn=1";
                web.Url = new Uri(urll);

                System.Diagnostics.Process.Start(urll);
            }
            catch {
                MessageBox.Show("乱点爆掉了吧，输入个关键词试试");
            }
        }   //著作权（ok）

        private void button11_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(@"C:\text"))
            {
                // 目录不存在，建立目录
                System.IO.Directory.CreateDirectory(@"C:\text");
            }
            try
            {
                String sourcePath = Application.StartupPath + "\\initial\\bx.mdb";
                String targetPath = Application.StartupPath + "\\bx.mdb";
                bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
                System.IO.File.Copy(sourcePath, targetPath, isrewrite);

                string sql = "";
                sql = "insert into [bxinfo]([name], [url], [time],[source]) values('" + "最新更新时间" + "','" + label2.Text + "','" + "点击可排序" + "','" + "admin" + "')";
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 

                con.Open(); //打开数据库连接  
                cmd.ExecuteNonQuery(); //执行Command命令  
                con.Close(); //关闭数据库连接 

                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                string sql1 = "select * from bxinfo";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "bxinfo");
                DataTable dt = thisDataSet.Tables["bxinfo"];
                this.dataGridView1.DataSource = dt;
                con1.Close();

            }



            catch {

                MessageBox.Show("哭脸，写入失败");
            }

        }  //初始化数据库

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string urll = "http://221.226.56.50/s46/843/list.psp";
                web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(title=').*?(>)").Matches(web_code);
                MatchCollection ms = new Regex("(href=').*?(page.psp)").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 14)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("title=", "");
                    name = name.Replace("'", "");
                    textBox1.Text = name;


                    string url = ms[i].Value;
                    url = url.Replace("href='", "");
                    textBox2.Text = "http://221.226.56.50/" + url;

                  //  string time = ms2[i].Value;
                  //  time = time.Replace("times\">", "");
                    textBox4.Text = ms2[i].Value;

                    // Thread.Sleep(2000);
                    string sql = "";
                    sql = "insert into [jssh]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + button12.Text + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }
                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                string sql1 = "select * from bxinfo";
                OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "bxinfo");
                DataTable dt = thisDataSet.Tables["bxinfo"];
                this.dataGridView1.DataSource = dt;
                con1.Close();
                MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
            }
            catch
            {
                MessageBox.Show("请求失败，联系小哥哥吧");
            }
        }  //江苏海事

        private async void button13_Click(object sender, EventArgs e)  //---开启监控按钮
        {
            timer3.Enabled = true;

            panel1.BackColor = Color.Green;

            label9.Text = "准备开始运行";
            label10.Text = "1";
            

            try
            {
                String sourcePath = Application.StartupPath + "\\initial\\bx.mdb";
                String targetPath = Application.StartupPath + "\\initial\\new\\bx.mdb";
                bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
                System.IO.File.Copy(sourcePath, targetPath, isrewrite);
            }


            catch
            {
            } //初始化数据库

            try
            {

                string sql = "";
                sql = "insert into [bxinfo]([name], [url], [time],[source]) values('" + label2.Text + "','" + label2.Text + "','" + "点击可排序" + "','" + "更新时间:" + "')";
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 

                con.Open(); //打开数据库连接  
                cmd.ExecuteNonQuery(); //执行Command命令  
                con.Close(); //关闭数据库连接 
            }
            catch {

            }  //写入更新时间

            try
            {
                label5.Text = "当前运行【广西政采】";
                // web.Url = new Uri("http://www.gxgp.gov.cn/cggkzb/index.htm");
                HttpClient httpClient11 = new HttpClient();
                httpClient11.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.14955");
                HttpResponseMessage response11 = await httpClient11.GetAsync(new Uri("http://www.gxgp.gov.cn/cggkzb/index_1.htm"));
                response11.EnsureSuccessStatusCode();//确保请求成功  
                string result11 = await response11.Content.ReadAsStringAsync();
                rout.Text = result11;//输出源码到文本框
                string web_code = result11;
                MatchCollection ms1 = new Regex("(title=).*?(><span)").Matches(web_code);
                MatchCollection ms = new Regex("(http://www.gxgp.gov.cn/cggkzb/1).*?(htm)").Matches(web_code);
                MatchCollection ms2 = new Regex("(f-right\">).*?(</div>)").Matches(web_code);

                int i = 0;
                while (i < 20)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("title=\"", "");
                    name = name.Replace("\"><span", "");
                    textBox1.Text = name;


                    textBox2.Text = ms[i].Value;

                    string time = ms2[i].Value;
                    time = time.Replace("f-right\">", "");
                    time = time.Replace("</div>", "");
                    textBox4.Text = time;
                    // Thread.Sleep(2000);
                    string js = "广西政采" + i;
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象  
                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;

                }

            }
            catch
            {

            }  //广西政采
            System.Threading.Thread.Sleep(2000);

            try
            {
                label5.Text = "当前运行【湖南工院】";
                string urll = "http://www.hunangy.com/html/news/gonggao/index.html";
                //  web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("gb2312"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(color=''>).*?(</font>)").Matches(web_code);
                MatchCollection ms = new Regex("(/html/news/gonggao/).*?(.html)").Matches(web_code);
                MatchCollection ms2 = new Regex("(808080\">).*?(</font>)").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 30)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("color=''>", "");
                    name = name.Replace("</font>", "");
                    textBox1.Text = name;


                    textBox2.Text = "http://www.hunangy.com" + ms[i].Value;

                    string time = ms2[i].Value;
                    time = time.Replace("808080\">", "");
                    time = time.Replace("</font>", "");
                    textBox4.Text = time;


                    // Thread.Sleep(2000);
                    string js = "湖南工院" + i;
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

            }
            catch
            {

            }  //湖南工程
            System.Threading.Thread.Sleep(2000);

            try
            {
                label5.Text = "当前运行【湖南商学院】";
                string urll = "http://www.hnuc.edu.cn/column/zbxx/index.shtml";
                // web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(style=\"\">).*?(</a>)").Matches(web_code);
                MatchCollection ms = new Regex("(/column/zbxx/2).*?(.shtml)").Matches(web_code);
                MatchCollection ms2 = new Regex("(times\">)\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 20)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("style=\"\">", "");
                    name = name.Replace("</a>", "");
                    textBox1.Text = name;


                    textBox2.Text = "http://www.hnuc.edu.cn" + ms[i].Value;

                    string time = ms2[i].Value;
                    time = time.Replace("times\">", "");
                    textBox4.Text = time;

                    // Thread.Sleep(2000);
                    string js = "湖南商学院" + i;
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

            }
            catch
            {

            }   //湖南商学院
            System.Threading.Thread.Sleep(2000);

            try
            {
                label5.Text = "当前运行【湖南现代】";
                string urll = "http://www.56edu.com/list.jsp?urltype=tree.TreeTempUrl&wbtreeid=1049";
                // web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(title=\").*?(style=)").Matches(web_code);
                MatchCollection ms = new Regex("(show.jsp).*?(wbnewsid=)\\d{4}").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 15)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("title=\"", "");
                    name = name.Replace("style=", "");
                    name = name.Replace("\"", "");
                    textBox1.Text = name;


                    textBox2.Text = "http://www.56edu.com/" + ms[i].Value;

                    string time = ms2[i].Value;
                    // time = time.Replace("times\">", "");
                    textBox4.Text = time;

                    // Thread.Sleep(2000);
                    string js = "湖南现代" + i;
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

            }
            catch
            {

            }   //湖南现代
            System.Threading.Thread.Sleep(2000);

            try
            {
                label5.Text = "当前运行【民大相思湖】";
                string urll = "http://xshxy.cn/xwzx/cggg.htm";
                // web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(title=\"【).*?(\">)").Matches(web_code);
                MatchCollection ms = new Regex("(/info).*?(.htm)").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                int a = 0;
                while (i < 7)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("title=", "");
                    name = name.Replace(">", "");
                    name = name.Replace("\"", "");
                    //  name = name.Replace("【", "");
                    textBox1.Text = name;

                    string url = "http://xshxy.cn" + ms[a].Value;
                    url = url.Replace("target = ", "");
                    textBox2.Text = url;



                    string time = ms2[i].Value;
                    // time = time.Replace("times\">", "");
                    textBox4.Text = time;

                    // Thread.Sleep(2000);
                    string js = "民大相思湖" + i;
                    string sql = "";
                    sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    a = a + 2;



                }

            }
            catch
            {
                //  MessageBox.Show("请求失败，联系小哥哥吧");
            }   //民大相思湖
            System.Threading.Thread.Sleep(2000);

            try
            {
                label5.Text = "当前运行【江苏海事】";
                string urll = "http://221.226.56.50/_s46/843/list.psp";
                //  web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex("(title=').*?(>)").Matches(web_code);
                MatchCollection ms = new Regex("(href=').*?(page.psp)").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 14)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("title=", "");
                    name = name.Replace("'", "");
                    textBox1.Text = name;


                    string url = ms[i].Value;
                    url = url.Replace("href='", "");
                    textBox2.Text = "http://221.226.56.50" + url;

                    //  string time = ms2[i].Value;
                    //  time = time.Replace("times\">", "");
                    textBox4.Text = ms2[i].Value;

                    // Thread.Sleep(2000);
                    string js = "江苏海事" + i;
                    string sql = "";
                    sql = "insert into [jssh]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

                //  MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
            }
            catch
            {
                //  MessageBox.Show("请求失败，联系小哥哥吧");
            }   //江苏海事职院
            System.Threading.Thread.Sleep(2000);


            try
            {
                label5.Text = "当前运行【贵州装备制造】";
                string urll = "http://www.gzzbzy.cn/tzgg_.htm";
                //  web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码

                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex(@"(/b>)\s*.*\s").Matches(web_code);
                MatchCollection ms = new Regex("(info).*?(.htm)").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 10)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("/b>", "");
                    name = name.Replace(" ", "");
                    name = name.Replace("\r\n", "");
                    textBox1.Text = name;


                    string url = ms[i].Value;
                    //  url = url.Replace("href='", "");
                    textBox2.Text = "http://www.gzzbzy.cn/" + url;

                    //  string time = ms2[i].Value;
                    //  time = time.Replace("times\">", "");
                    textBox4.Text = ms2[i].Value;

                    // Thread.Sleep(2000);
                    string js = "贵州装备制造" + i;
                    string sql = "";
                    sql = "insert into [gzyn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

                //  MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
            }
            catch
            {
                //   MessageBox.Show("请求失败，联系小哥哥吧");
            }  //贵州装备制造
            System.Threading.Thread.Sleep(2000);

            try
            {
                label5.Text = "当前运行【四川政采】";
                string urll = "http://www.sczfcg.com/CmsNewsController.do?method=recommendBulletinList&rp=25&page=1&moreType=provincebuyBulletinMore&channelCode=sjcg2";
                //  web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码

                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex(@"(blank).*(</a>)").Matches(web_code);
                MatchCollection ms = new Regex("(/view/staticpags/shiji).*?(html)").Matches(web_code);
                //  MatchCollection ms2 = new Regex("\\d{2}-\\d{2}").Matches(web_code);


                int i = 1;
                // int a = 0;
                while (i < 26)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("blank\">", "");
                    name = name.Replace("</a>", "");
                    // name = name.Replace("\r\n", "");
                    textBox1.Text = name;


                    string url = ms[i].Value;
                    //  url = url.Replace("href='", "");
                    textBox2.Text = "http://www.sczfcg.com" + url;

                    //  string time = ms2[i].Value;
                    //  time = time.Replace("times\">", "");
                    // textBox4.Text = ms2[i].Value;
                    textBox4.Text = "No Date";
                    // Thread.Sleep(2000);
                    string js = "四川政采" + i;
                    string sql = "";
                    sql = "insert into [cqxzsc]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

                // MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
            }
            catch
            {
                // MessageBox.Show("请求失败，联系小哥哥吧");
            }  //四川政采
            System.Threading.Thread.Sleep(2000);


            try
            {
                String sourcePath = Application.StartupPath + "\\initial\\new\\bx.mdb";
                String targetPath = Application.StartupPath + "\\bx.mdb";
                bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
                System.IO.File.Copy(sourcePath, targetPath, isrewrite);

              
            }



            catch
            {


            } //复制数据库
            System.Threading.Thread.Sleep(200);

            label9.Text = "休息";
            panel1.BackColor = Color.Yellow;

            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
            string sql1 = "select * from bxinfo";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "bxinfo");
            DataTable dt = thisDataSet.Tables["bxinfo"];
            this.dataGridView1.DataSource = dt;
            con1.Close();

          

        }

        private async void timer3_Tick(object sender, EventArgs e)
        {
           

            panel1.BackColor = Color.Green;

            label9.Text = "正在运行";

            string ab = label10.Text;


                try
                {
                    String sourcePath = Application.StartupPath + "\\initial\\bx.mdb";
                    String targetPath = Application.StartupPath + "\\initial\\new\\bx.mdb";
                    bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
                    System.IO.File.Copy(sourcePath, targetPath, isrewrite);
                }


                catch
                {
                } //初始化数据库

                try
                {

                    string sql = "";
                    sql = "insert into [bxinfo]([name], [url], [time],[source]) values('" +label2.Text + "','" + label2.Text + "','" + "点击可排序" + "','" + "更新时间" + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 

                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 
                }
                catch
                {

                }  //写入更新时间

                try
                {
                    label5.Text = "当前运行【广西政采】";
                   // web.Url = new Uri("http://www.gxgp.gov.cn/cggkzb/index.htm");
                    HttpClient httpClient11 = new HttpClient();
                    httpClient11.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.14955");
                    HttpResponseMessage response11 = await httpClient11.GetAsync(new Uri("http://www.gxgp.gov.cn/cggkzb/index_1.htm"));
                    response11.EnsureSuccessStatusCode();//确保请求成功  
                    string result11 = await response11.Content.ReadAsStringAsync();
                    rout.Text = result11;//输出源码到文本框
                    string web_code = result11;
                    MatchCollection ms1 = new Regex("(title=).*?(><span)").Matches(web_code);
                    MatchCollection ms = new Regex("(http://www.gxgp.gov.cn/cggkzb/1).*?(htm)").Matches(web_code);
                    MatchCollection ms2 = new Regex("(f-right\">).*?(</div>)").Matches(web_code);

                    int i = 0;
                    while (i < 20)
                    {
                        string name = ms1[i].Value;
                        name = name.Replace("title=\"", "");
                        name = name.Replace("\"><span", "");
                        textBox1.Text = name;


                        textBox2.Text = ms[i].Value;

                        string time = ms2[i].Value;
                        time = time.Replace("f-right\">", "");
                        time = time.Replace("</div>", "");
                        textBox4.Text = time;
                        // Thread.Sleep(2000);
                        string js = "广西政采"+i;
                        string sql = "";
                        sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                        OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象  
                        con.Open(); //打开数据库连接  
                        cmd.ExecuteNonQuery(); //执行Command命令  
                        con.Close(); //关闭数据库连接 

                        i++;

                    }

                }
                catch
                {

                }  //广西政采
                System.Threading.Thread.Sleep(2000);

                try
                {
                    label5.Text = "当前运行【湖南工院】";
                    string urll = "http://www.hunangy.com/html/news/gonggao/index.html";
                  //  web.Url = new Uri(urll);

                    string html = "";
                    HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                    WebResponse Response = hWebRequest.GetResponse();
                    HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                    StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("gb2312"));//这里设置编码
                    rout.Text = html = sr.ReadToEnd();
                    string web_code = html;
                    MatchCollection ms1 = new Regex("(color=''>).*?(</font>)").Matches(web_code);
                    MatchCollection ms = new Regex("(/html/news/gonggao/).*?(.html)").Matches(web_code);
                    MatchCollection ms2 = new Regex("(808080\">).*?(</font>)").Matches(web_code);


                    int i = 0;
                    // int a = 0;
                    while (i < 30)
                    {
                        string name = ms1[i].Value;
                        name = name.Replace("color=''>", "");
                        name = name.Replace("</font>", "");
                        textBox1.Text = name;


                        textBox2.Text = "http://www.hunangy.com" + ms[i].Value;

                        string time = ms2[i].Value;
                        time = time.Replace("808080\">", "");
                        time = time.Replace("</font>", "");
                        textBox4.Text = time;


                        // Thread.Sleep(2000);
                        string js = "湖南工院" + i;
                        string sql = "";
                        sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                        OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                        con.Open(); //打开数据库连接  
                        cmd.ExecuteNonQuery(); //执行Command命令  
                        con.Close(); //关闭数据库连接 

                        i++;
                        // a = a + 2;



                    }

                }
                catch
                {

                }  //湖南工程
                System.Threading.Thread.Sleep(2000);

                try
                {
                    label5.Text = "当前运行【湖南商学院】";
                    string urll = "http://www.hnuc.edu.cn/column/zbxx/index.shtml";
                   // web.Url = new Uri(urll);

                    string html = "";
                    HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                    WebResponse Response = hWebRequest.GetResponse();
                    HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                    StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                    rout.Text = html = sr.ReadToEnd();
                    string web_code = html;
                    MatchCollection ms1 = new Regex("(style=\"\">).*?(</a>)").Matches(web_code);
                    MatchCollection ms = new Regex("(/column/zbxx/2).*?(.shtml)").Matches(web_code);
                    MatchCollection ms2 = new Regex("(times\">)\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                    int i = 0;
                    // int a = 0;
                    while (i < 20)
                    {
                        string name = ms1[i].Value;
                        name = name.Replace("style=\"\">", "");
                        name = name.Replace("</a>", "");
                        textBox1.Text = name;


                        textBox2.Text = "http://www.hnuc.edu.cn" + ms[i].Value;

                        string time = ms2[i].Value;
                        time = time.Replace("times\">", "");
                        textBox4.Text = time;

                        // Thread.Sleep(2000);
                        string js = "湖南商学院" + i;
                        string sql = "";
                        sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                        OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                        con.Open(); //打开数据库连接  
                        cmd.ExecuteNonQuery(); //执行Command命令  
                        con.Close(); //关闭数据库连接 

                        i++;
                        // a = a + 2;



                    }

                }
                catch
                {

                }   //湖南商学院
                System.Threading.Thread.Sleep(2000);

                try
                {
                    label5.Text = "当前运行【湖南现代】";
                    string urll = "http://www.56edu.com/list.jsp?urltype=tree.TreeTempUrl&wbtreeid=1049";
                   // web.Url = new Uri(urll);

                    string html = "";
                    HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                    WebResponse Response = hWebRequest.GetResponse();
                    HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                    StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                    rout.Text = html = sr.ReadToEnd();
                    string web_code = html;
                    MatchCollection ms1 = new Regex("(title=\").*?(style=)").Matches(web_code);
                    MatchCollection ms = new Regex("(show.jsp).*?(wbnewsid=)\\d{4}").Matches(web_code);
                    MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                    int i = 0;
                    // int a = 0;
                    while (i < 15)
                    {
                        string name = ms1[i].Value;
                        name = name.Replace("title=\"", "");
                        name = name.Replace("style=", "");
                        name = name.Replace("\"", "");
                        textBox1.Text = name;


                        textBox2.Text = "http://www.56edu.com/" + ms[i].Value;

                        string time = ms2[i].Value;
                        // time = time.Replace("times\">", "");
                        textBox4.Text = time;

                        // Thread.Sleep(2000);
                        string js = "湖南现代" + i;
                        string sql = "";
                        sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                        OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                        con.Open(); //打开数据库连接  
                        cmd.ExecuteNonQuery(); //执行Command命令  
                        con.Close(); //关闭数据库连接 

                        i++;
                        // a = a + 2;



                    }

                }
                catch
                {

                }   //湖南现代
                System.Threading.Thread.Sleep(2000);

                try
                {
                    label5.Text = "当前运行【民大相思湖】";
                    string urll = "http://xshxy.cn/xwzx/cggg.htm";
                   // web.Url = new Uri(urll);

                    string html = "";
                    HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                    WebResponse Response = hWebRequest.GetResponse();
                    HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                    StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                    rout.Text = html = sr.ReadToEnd();
                    string web_code = html;
                    MatchCollection ms1 = new Regex("(title=\"【).*?(\">)").Matches(web_code);
                    MatchCollection ms = new Regex("(/info).*?(.htm)").Matches(web_code);
                    MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                    int i = 0;
                    int a = 0;
                    while (i < 7)
                    {
                        string name = ms1[i].Value;
                        name = name.Replace("title=", "");
                        name = name.Replace(">", "");
                        name = name.Replace("\"", "");
                        //  name = name.Replace("【", "");
                        textBox1.Text = name;

                        string url = "http://xshxy.cn" + ms[a].Value;
                        url = url.Replace("target = ", "");
                        textBox2.Text = url;



                        string time = ms2[i].Value;
                        // time = time.Replace("times\">", "");
                        textBox4.Text = time;

                        // Thread.Sleep(2000);
                        string js = "民大相思湖" + i;
                        string sql = "";
                        sql = "insert into [gxhn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                        OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                        con.Open(); //打开数据库连接  
                        cmd.ExecuteNonQuery(); //执行Command命令  
                        con.Close(); //关闭数据库连接 

                        i++;
                        a = a + 2;



                    }

                }
                catch
                {
                  //  MessageBox.Show("请求失败，联系小哥哥吧");
                }   //民大相思湖
                System.Threading.Thread.Sleep(2000);

                try
                {
                    label5.Text = "当前运行【江苏海事】";
                    string urll = "http://221.226.56.50/_s46/843/list.psp";
                  //  web.Url = new Uri(urll);

                    string html = "";
                    HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                    WebResponse Response = hWebRequest.GetResponse();
                    HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                    StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码
                    rout.Text = html = sr.ReadToEnd();
                    string web_code = html;
                    MatchCollection ms1 = new Regex("(title=').*?(>)").Matches(web_code);
                    MatchCollection ms = new Regex("(href=').*?(page.psp)").Matches(web_code);
                    MatchCollection ms2 = new Regex("\\d{4}-\\d{2}-\\d{2}").Matches(web_code);


                    int i = 0;
                    // int a = 0;
                    while (i < 14)
                    {
                        string name = ms1[i].Value;
                        name = name.Replace("title=", "");
                        name = name.Replace("'", "");
                        textBox1.Text = name;


                        string url = ms[i].Value;
                        url = url.Replace("href='", "");
                        textBox2.Text = "http://221.226.56.50" + url;

                        //  string time = ms2[i].Value;
                        //  time = time.Replace("times\">", "");
                        textBox4.Text = ms2[i].Value;

                        // Thread.Sleep(2000);
                        string js = "江苏海事" + i;
                        string sql = "";
                        sql = "insert into [jssh]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                        OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                        con.Open(); //打开数据库连接  
                        cmd.ExecuteNonQuery(); //执行Command命令  
                        con.Close(); //关闭数据库连接 

                        i++;
                        // a = a + 2;



                    }

                    //  MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
                }
                catch
                {
                    //  MessageBox.Show("请求失败，联系小哥哥吧");
                }   //江苏海事职院
                System.Threading.Thread.Sleep(2000);

            try
            {
                label5.Text = "当前运行【贵州装备制造】";
                string urll = "http://www.gzzbzy.cn/tzgg_.htm";
                //  web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码

                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex(@"(/b>)\s*.*\s").Matches(web_code);
                MatchCollection ms = new Regex("(info).*?(.htm)").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 10)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("/b>", "");
                    name = name.Replace(" ", "");
                    name = name.Replace("\r\n", "");
                    textBox1.Text = name;


                    string url = ms[i].Value;
                    //  url = url.Replace("href='", "");
                    textBox2.Text = "http://www.gzzbzy.cn/" + url;

                    //  string time = ms2[i].Value;
                    //  time = time.Replace("times\">", "");
                    textBox4.Text = ms2[i].Value;

                    // Thread.Sleep(2000);
                    string js = "贵州装备制造" + i;
                    string sql = "";
                    sql = "insert into [gzyn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

                //  MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
            }
            catch
            {
                //   MessageBox.Show("请求失败，联系小哥哥吧");
            }  //贵州装备制造
            System.Threading.Thread.Sleep(2000);

            try
            {
                label5.Text = "当前运行【四川政采】";
                string urll = "http://www.sczfcg.com/CmsNewsController.do?method=recommendBulletinList&rp=25&page=1&moreType=provincebuyBulletinMore&channelCode=sjcg2";
                //  web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码

                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex(@"(blank).*(</a>)").Matches(web_code);
                MatchCollection ms = new Regex("(/view/staticpags/shiji).*?(html)").Matches(web_code);
                //  MatchCollection ms2 = new Regex("\\d{2}-\\d{2}").Matches(web_code);


                int i = 1;
                // int a = 0;
                while (i < 26)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("blank\">", "");
                    name = name.Replace("</a>", "");
                    // name = name.Replace("\r\n", "");
                    textBox1.Text = name;


                    string url = ms[i].Value;
                    //  url = url.Replace("href='", "");
                    textBox2.Text = "http://www.sczfcg.com" + url;

                    //  string time = ms2[i].Value;
                    //  time = time.Replace("times\">", "");
                    // textBox4.Text = ms2[i].Value;
                    textBox4.Text = "No Date";
                    // Thread.Sleep(2000);
                    string js = "四川政采" + i;
                    string sql = "";
                    sql = "insert into [cqxzsc]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\initial\\new\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

               // MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
            }
            catch
            {
               // MessageBox.Show("请求失败，联系小哥哥吧");
            }  //四川政采
            System.Threading.Thread.Sleep(2000);

            try
                {
                    String sourcePath = Application.StartupPath + "\\initial\\new\\bx.mdb";
                    String targetPath = Application.StartupPath + "\\bx.mdb";
                    bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
                    System.IO.File.Copy(sourcePath, targetPath, isrewrite);
                }


                catch
                {
                } //复制数据库
               System.Threading.Thread.Sleep(100);

            int aab = int.Parse(ab);
            aab = aab + 1;
            label10.Text = aab.ToString();

            label9.Text = "休息";
            panel1.BackColor = Color.Yellow;

                OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
            string sql1 = "select * from bxinfo";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql1, con1);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "bxinfo");
            DataTable dt = thisDataSet.Tables["bxinfo"];
            this.dataGridView1.DataSource = dt;
            con1.Close();

            

               // label10.Text = (Total++).ToString();
           
        }  //-------自动监控

        private void button14_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            label9.Text = "未运行";
            panel1.BackColor = Color.Red;
        }  //关闭监控

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                label5.Text = "当前运行【贵州装备制造】";
                string urll = "http://www.gzzbzy.cn/tzgg_.htm";
                //  web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码

                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex(@"(/b>)\s*.*\s").Matches(web_code);
                MatchCollection ms = new Regex("(info).*?(.htm)").Matches(web_code);
                MatchCollection ms2 = new Regex("\\d{2}-\\d{2}").Matches(web_code);


                int i = 0;
                // int a = 0;
                while (i < 10)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("/b>", "");
                   name = name.Replace(" ", "");
                    name = name.Replace("\r\n", "");
                    textBox1.Text = name;


                    string url = ms[i].Value;
                    //  url = url.Replace("href='", "");
                    textBox2.Text = "http://www.gzzbzy.cn/" + url;

                    //  string time = ms2[i].Value;
                    //  time = time.Replace("times\">", "");
                    textBox4.Text = ms2[i].Value;

                    // Thread.Sleep(2000);
                    string js = "贵州装备制造" + i;
                    string sql = "";
                    sql = "insert into [gzyn]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

                 MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
            }
            catch
            {
                  MessageBox.Show("请求失败，联系小哥哥吧");
            }   
           // System.Threading.Thread.Sleep(2000);
        }  //贵州装备制造

        private void button16_Click(object sender, EventArgs e)  //四川政采
        {
            try
            {
                label5.Text = "当前运行【四川政采】";
                string urll = "http://www.sczfcg.com/CmsNewsController.do?method=recommendBulletinList&rp=25&page=1&moreType=provincebuyBulletinMore&channelCode=sjcg2";
                //  web.Url = new Uri(urll);

                string html = "";
                HttpWebRequest hWebRequest = (HttpWebRequest)WebRequest.Create(urll);
                WebResponse Response = hWebRequest.GetResponse();
                HttpWebResponse wr = (HttpWebResponse)hWebRequest.GetResponse();
                StreamReader sr = new StreamReader(Response.GetResponseStream(), Encoding.GetEncoding("utf-8"));//这里设置编码

                rout.Text = html = sr.ReadToEnd();
                string web_code = html;
                MatchCollection ms1 = new Regex(@"(blank).*(</a>)").Matches(web_code);
                MatchCollection ms = new Regex("(/view/staticpags/shiji).*?(html)").Matches(web_code);
              //  MatchCollection ms2 = new Regex("\\d{2}-\\d{2}").Matches(web_code);


                int i = 1;
                // int a = 0;
                while (i < 26)
                {
                    string name = ms1[i].Value;
                    name = name.Replace("blank\">", "");
                    name = name.Replace("</a>", "");
                   // name = name.Replace("\r\n", "");
                    textBox1.Text = name;


                    string url = ms[i].Value;
                    //  url = url.Replace("href='", "");
                    textBox2.Text = "http://www.sczfcg.com" + url;

                    //  string time = ms2[i].Value;
                    //  time = time.Replace("times\">", "");
                    // textBox4.Text = ms2[i].Value;
                    textBox4.Text = "No Date";
                    // Thread.Sleep(2000);
                    string js = "四川政采" + i;
                    string sql = "";
                    sql = "insert into [cqxzsc]([name], [url], [time],[source]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + js + "')";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\bx.mdb");
                    OleDbCommand cmd = new OleDbCommand(sql, con); //定义Command对象 



                    con.Open(); //打开数据库连接  
                    cmd.ExecuteNonQuery(); //执行Command命令  
                    con.Close(); //关闭数据库连接 

                    i++;
                    // a = a + 2;



                }

                  MessageBox.Show("已经写入" + button12.Text + "条数据，请查看数据库");
            }
            catch
            {
                   MessageBox.Show("请求失败，联系小哥哥吧");
            }
          
        }
    }
}
