using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using xNet;

namespace HttpRequestDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetData(object sender, EventArgs e)
        {
            var kteamUrl = "https://howkteam.vn/";
            var html = GetData(kteamUrl);
            DisplayData(html);

        }

        private void DisplayData(string html)
        {
            File.WriteAllText("gotData.html", html);
            Process.Start("gotData.html");
        }

        private string GetData(string url)
        {
            var httpRequest = new HttpRequest();
            httpRequest.UserAgent = Http.ChromeUserAgent();
            var html = httpRequest.Get(url).ToString();
            return html;
        }
    }
}
