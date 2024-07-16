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
    }
}