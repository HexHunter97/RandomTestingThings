using System;

namespace ArmaReforger.WorkshopBrowser.Client.Dtos
{
    public class AssetAuthor
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        public bool Verified { get; set; }
        public bool Blocked { get; set; }
        public bool Developer { get; set; }
        public bool Admin { get; set; }
    }
    /*
{
    "id": "47af26c9-213d-48cb-b14d-fae404dfbf00",
    "username": "Bohemia Interactive",
    "verified": true,
    "blocked": false,
    "developer": false,
    "admin": false
}
     */
}
