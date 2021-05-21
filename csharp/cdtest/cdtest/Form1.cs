using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace cdtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string openDataFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string a = "";

            openFileDialog1.InitialDirectory = "..";
            openFileDialog1.Filter = "txt files (*.*)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    a = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar archivo: " + ex.Message);
                }
            }
            return a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = this.openDataFile();
            string str = @"E:\csharp-cpp\cpp\ab-test\Debug\ab-test.exe " + "\"" + filename + "\"";

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令



            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //char[] aaa = { '\\', 'r', '\\', 'n' };
            string[] mutliLine = Regex.Split(output, @"\r\n");
            for(int i = 4; i < mutliLine.Length; i++)
            {
                this.richTextBox1.Text += mutliLine[i] + "\r\n";
            }

            //this.richTextBox1.Text = output;
            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


            Console.WriteLine(output);
        }
    }
}
