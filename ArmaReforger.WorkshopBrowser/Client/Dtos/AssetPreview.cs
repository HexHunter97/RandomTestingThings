namespace ArmaReforger.WorkshopBrowser.Client.Dtos
{
    public class AssetPreview : AssetThumbnail
    {
        public AssetImages Thumbnails { get; set; } = default!;
    }

    /*
{
    "url": "https://ar-gcp-cdn.bistudio.com/image/85b7/730096ee70b04f08bf91ed093306d9ca.jpg",
    "width": 1920,
    "height": 1080,
    "thumbnails": {
        "image/jpeg": [
            {
                "url": "https://ar-gcp-cdn.bistudio.com/image/9a0c/654b63486e542d27efb7edcde6a15b4b.jpg",
                "width": 1152,
                "height": 648,
                "contentType": "image/jpeg"
            },
            {
                "url": "https://ar-gcp-cdn.bistudio.com/image/7fbc/40d3aeb42f79f737aaa89de14043cf76.jpg",
                "width": 576,
                "height": 324,
                "contentType": "image/jpeg"
            },
            {
                "url": "https://ar-gcp-cdn.bistudio.com/image/a2e6/2ee3b52d5add54892ea857148c13cd59.jpg",
                "width": 288,
                "height": 162,
                "contentType": "image/jpeg"
            }
        ]
    },
    "contentType": "image/jpeg"
}
     */
}
