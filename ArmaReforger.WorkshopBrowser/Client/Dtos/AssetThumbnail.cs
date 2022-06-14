namespace ArmaReforger.WorkshopBrowser.Client.Dtos
{
    public class AssetThumbnail
    {
        public string Url { get; set; } = default!;
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContentType { get; set; } = default!;
    }
    /*
{
    "url": "https://ar-gcp-cdn.bistudio.com/image/7fbc/40d3aeb42f79f737aaa89de14043cf76.jpg",
    "width": 576,
    "height": 324,
    "contentType": "image/jpeg"
}
     */
}
