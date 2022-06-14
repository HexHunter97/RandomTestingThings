using System;

namespace ArmaReforger.WorkshopBrowser.Client.Dtos
{
    public class Asset
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Summary { get; set; } = default!;
        public bool Unlisted { get; set; }
        public bool Private { get; set; }
        public bool Blocked { get; set; }
        public int RatingCount { get; set; }
        public double AverageRating { get; set; }
        public int SubscriberCount { get; set; }
        public string CurrentVersionNumber { get; set; } = default!;
        public long CurrentVersionSize { get; set; } = default!;
        public AssetPreview[] Previews { get; set; } = Array.Empty<AssetPreview>();
        public object Meta { get; set; } = default!;    // TODO: unknown type
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AssetTag[] Tags { get; set; } = Array.Empty<AssetTag>();
        public AssetAuthor Author { get; set; } = default!;
    }

    /*
{
    "averageRating": 0.77,
    "id": "5614E48126E3ADF2",
    "name": "Sample Mod - New Faction",
    "summary": "Example of a new faction",
    "unlisted": false,
    "private": false,
    "blocked": false,
    "ratingCount": 44,
    "subscriberCount": 5514,
    "currentVersionNumber": "1.0.1",
    "currentVersionSize": 19987588,
    "previews": [
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
    ],
    "meta": null,
    "createdAt": "2022-05-17T21:19:56.000Z",
    "updatedAt": "2022-05-19T08:04:22.000Z",
    "tags": [
        {
            "name": "CONFLICT",
            "category": null
        },
        {
            "name": "FACTION",
            "category": null
        },
        {
            "name": "SAMPLE",
            "category": null
        }
    ],
    "author": {
        "id": "47af26c9-213d-48cb-b14d-fae404dfbf00",
        "username": "Bohemia Interactive",
        "verified": true,
        "blocked": false,
        "developer": false,
        "admin": false
    }
}
     */
}
