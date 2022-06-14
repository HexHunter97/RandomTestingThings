using System.Text;

namespace ArmaReforger.WorkshopBrowser.Client
{
    public static class Helpers
    {
        public static void AppendQueryString(this StringBuilder builder, string? value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            builder.Append($"&{name}={value}");
        }
    }
}
