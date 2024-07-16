using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HttpRequestDemo.Helper;
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
            var html = ActionHelper.GetData(Constants.KTeamHomeUrl);
            DisplayData(html);
        }

        private void GetDataWithCookie(object sender, EventArgs e)
        {
            var cookieStr = Constants.Cookie;

            var html = ActionHelper.GetData(Constants.KTeamHomeUrl, null, cookieStr);
            DisplayData(html);
        }


        private void PostLogin(object sender, EventArgs e)
        {
            var httpRequest = new HttpRequest();
            httpRequest.Cookies = new CookieDictionary();

            var html = ActionHelper.GetData(Constants.KTeamHomeUrl, httpRequest, null, Constants.UserAgent);

            var token = GetLoginDataToken(html);

            var userName = Constants.UserName;
            var password = Constants.Password;
            var data = "__RequestVerificationToken=" + token + "&Email=" + WebUtility.UrlEncode(userName) + "&Password=" + WebUtility.UrlEncode(password) + "&RememberMe=true&RememberMe=false";
            ActionHelper.PostData(httpRequest, Constants.KTeamLoginUrl, data, Constants.ContentType);

            html = ActionHelper.GetData(Constants.KTeamHomeUrl, httpRequest, null, Constants.UserAgent);

            DisplayData(html);
        }

        private string GetLoginDataToken(string html)
        {
            var token = "";
            var res = Regex.Matches(html, Constants.RegexMatchRequestVerificationToken, RegexOptions.Singleline);

            if (res.Count > 0)
            {
                token = res[0].ToString();
            }

            return token;
        }

        private void UploadFile(object sender, EventArgs e)
        {

        }

        private void DisplayData(string html)
        {
            File.WriteAllText("gotData.html", html);
            Process.Start("gotData.html");
        }
    }
}
