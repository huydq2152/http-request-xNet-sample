using System.Diagnostics;
using System.IO;
using HttpRequestDemo.Models;
using Newtonsoft.Json;
using xNet;

namespace HttpRequestDemo.Helper
{
    public static class ActionHelper
    {
        public static string PostData(HttpRequest http, string url, string data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                RequestHelper.AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }

            var html = http.Post(url, data, contentType).ToString();
            return html;
        }


        public static string GetData(string url, HttpRequest httpRequest = null, string cookieStr = null, string userArgent = null)
        {
            if (httpRequest == null)
            {
                httpRequest = new HttpRequest();
                httpRequest.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookieStr))
            {
                RequestHelper.AddCookie(httpRequest, cookieStr);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                httpRequest.UserAgent = Http.ChromeUserAgent();
            }

            var html = httpRequest.Get(url).ToString();
            return html;
        }

        public static string UploadData(HttpRequest httpRequest, string url, MultipartContent data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (httpRequest == null)
            {
                httpRequest = new HttpRequest();
                httpRequest.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                RequestHelper.AddCookie(httpRequest, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                httpRequest.UserAgent = userArgent;
            }

            var html = httpRequest.Post(url, data).ToString();
            return html;
        }

        public static void UploadFile(string path)
        {
            MultipartContent data = new MultipartContent() {
                { new StringContent("csrf_test_name"), "22ee6e7fc009db544f24be71ff18f51d"},
                { new StringContent("fuid"), "e36ea6440c7f4d1d646260c1d51e29bf"},
                { new StringContent("file_name"), Path.GetFileName(path)},
                { new StringContent("file_type"), "log"},
                { new StringContent("total_chunks"), "1"},
                { new FileContent(path), "file_name", Path.GetFileName(path)}
            };

            var html = UploadData(null, Constants.UploadFileUrl, data);

            var dataRes = JsonConvert.DeserializeObject<UploadFileResponse>(html);

            if (dataRes != null) Process.Start(dataRes.Destination);
        }
    }
}