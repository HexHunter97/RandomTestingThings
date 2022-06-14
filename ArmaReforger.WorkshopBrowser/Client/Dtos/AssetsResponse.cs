using System;

namespace ArmaReforger.WorkshopBrowser.Client.Dtos
{
    public class AssetsResponse
    {
        public int Count { get; set; }
        public Asset[] Rows { get; set; } = Array.Empty<Asset>();
    }
}
