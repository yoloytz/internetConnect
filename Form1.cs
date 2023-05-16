using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace internetConnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://hubu.edu.cn/";
            
            WebClient clinet = new WebClient();
            
            byte[] pageDate = clinet.DownloadData(url);
            
            string pageHtml = Encoding.UTF8.GetString(pageDate);

            richTextBox1.Text = pageHtml;

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://hubu.edu.cn/";
            string str = DownloadString(url);
            richTextBox2.Text = str;
        }
        private string DownloadString(string url)
        {
            try {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                Stream responsStream = response.GetResponseStream();

                Encoding encoding = Encoding.UTF8;

                StreamReader reader = new StreamReader(responsStream, encoding);
                
                string str = reader.ReadToEnd();
                reader.Close();
                responsStream.Close();
                response.Close();
                return str;
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return "执行中报错 " + ex.Message;
            }   

            return "程序未能执行";
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
