using xNet;

namespace HttpRequestDemo.Helper
{
    public static class RequestHelper
    {
        public static void AddCookie(HttpRequest httpRequest, string cookie)
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