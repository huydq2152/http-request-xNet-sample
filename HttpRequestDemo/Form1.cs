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

        private string GetData(string url, string cookieStr = null)
        {
            var httpRequest = new HttpRequest();
            httpRequest.Cookies = new CookieDictionary();

            if (!string.IsNullOrEmpty(cookieStr))
            {
                AddCookie(httpRequest, cookieStr);
            }

            httpRequest.UserAgent = Http.ChromeUserAgent();
            var html = httpRequest.Get(url).ToString();
            return html;
        }

        private void GetDataWithCookie(object sender, EventArgs e)
        {
            var kteamUrl = "https://howkteam.vn/";
            var cookieStr =
                "_ga=GA1.2.1038169450.1700994001; _gid=GA1.2.384866686.1721058845; __RequestVerificationToken=yqCu3vMr7usRsXnB4ZvLf-M28NiFRd2adeDgwU5nbmRiWI_U_N4i4t6mpQ51o2VEdx0q_11J6xdBHjBoUJn8ZXyMd0Eb8TLefPbgOaQj7Cg1; _gat=1; .AspNet.ApplicationCookie=NJIsN9ztChXE4U3Xngu81pUJvlHkrfaFgcximo_QgR7Z4woDADmVWm7hnJTykCd_MtYA-ZaqsjxmfIvDZaSiKORNWNQL0IyJ01eBHonikxe-zBUIpusCruEzwfu57CRXyYS9znHDb9YtAoj6Lpsxy5KgEFmYIeDow3CTlGAUwxjrhFHHSnDjCD8QMzC4ezb1uKte588Lw7xCNItoNNP19dImzU4OU-WtMNMxh5rrtfC6e3Y_yAPP2pEOEBDzvtNmZmovFxybKEWFwVS1Wo31zmps2lhsAfIMRe10dtI1MkP19Vg0epEcYijhwPp2H9U8gGL-thM8t2ryg1IcQ-zxWcftxfwlMmDDDhM9sTO8Sk4nSRjT6yE1Q34u-TiNmqHK6_r4b252iEZmDDRiKBvptCH4S03xGURL6ePP3Ui8pTC-pRQpXENXe4ZShkion4uQNN5FE7k4JQO6RjDtStPQgFZZYPW0ymL5Edy-fRN5fku8H9Okc_FDGvyCzO5tai-N";

            var html = GetData(kteamUrl, cookieStr);
            DisplayData(html);
        }

        private void AddCookie(HttpRequest httpRequest, string cookie)
        {
            var temp = cookie.Split(';');
            foreach (var item in temp)
            {
                var temp2 = item.Split('=');
                if (temp2.Length > 1)
                {
                    httpRequest.Cookies.Add(temp2[0], temp2[1]);
                }
            }
        }
    }
}
