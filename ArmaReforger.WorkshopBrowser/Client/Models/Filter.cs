namespace ArmaReforger.WorkshopBrowser.Client.Models
{
    public struct Filter
    {
        public string? Search { get; set; }
        public bool Unlisted { get; set; }
        public bool Private { get; set; }
        public bool Blocked { get; set; }
    }
}
