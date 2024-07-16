namespace HttpRequestDemo
{
    public static class Constants
    {
        public static string UserName { get; set; } = "quanghuy2152@gmail.com";
        public static string Password { get; set; } = "@Hh21052000";
        public static string Cookie { get; set; } = "_ga=GA1.2.1038169450.1700994001; _gid=GA1.2.384866686.1721058845; __RequestVerificationToken=yqCu3vMr7usRsXnB4ZvLf-M28NiFRd2adeDgwU5nbmRiWI_U_N4i4t6mpQ51o2VEdx0q_11J6xdBHjBoUJn8ZXyMd0Eb8TLefPbgOaQj7Cg1; _gat=1; .AspNet.ApplicationCookie=NJIsN9ztChXE4U3Xngu81pUJvlHkrfaFgcximo_QgR7Z4woDADmVWm7hnJTykCd_MtYA-ZaqsjxmfIvDZaSiKORNWNQL0IyJ01eBHonikxe-zBUIpusCruEzwfu57CRXyYS9znHDb9YtAoj6Lpsxy5KgEFmYIeDow3CTlGAUwxjrhFHHSnDjCD8QMzC4ezb1uKte588Lw7xCNItoNNP19dImzU4OU-WtMNMxh5rrtfC6e3Y_yAPP2pEOEBDzvtNmZmovFxybKEWFwVS1Wo31zmps2lhsAfIMRe10dtI1MkP19Vg0epEcYijhwPp2H9U8gGL-thM8t2ryg1IcQ-zxWcftxfwlMmDDDhM9sTO8Sk4nSRjT6yE1Q34u-TiNmqHK6_r4b252iEZmDDRiKBvptCH4S03xGURL6ePP3Ui8pTC-pRQpXENXe4ZShkion4uQNN5FE7k4JQO6RjDtStPQgFZZYPW0ymL5Edy-fRN5fku8H9Okc_FDGvyCzO5tai-N";
        public static string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
        public static string ContentType { get; set; } = "application/x-www-form-urlencoded; charset=UTF-8";
        public static string RegexMatchRequestVerificationToken { get; set; } = @"(?<=__RequestVerificationToken"" type=""hidden"" value="").*?(?="")";
        public static string KTeamHomeUrl { get; set; } = "https://howkteam.vn/";
        public static string KTeamLoginUrl { get; set; } = "https://howkteam.vn/account/login?ReturnUrl=%2F";
        public static string UploadFileUrl { get; set; } = "https://ufile.io/upload";
    }
}