namespace HttpRequestDemo.Models
{
    public class UploadFileResponse
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Destination { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Slug { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Expiry { get; set; }
        public int Location { get; set; }
    }
}