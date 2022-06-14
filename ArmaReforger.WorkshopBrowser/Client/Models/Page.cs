namespace ArmaReforger.WorkshopBrowser.Client.Models
{
    public struct Pagination
    {
        public const int DefaultPageSize = 5;

        public Pagination() : this(DefaultPageSize)
        { }

        public Pagination(int pageSize = DefaultPageSize, int pageNumber = 0)
        {
            Limit = pageSize;
            Offset = pageSize * pageNumber;
        }

        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
