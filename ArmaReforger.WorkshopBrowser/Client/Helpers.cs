using System;
using System.Text;

namespace ArmaReforger.WorkshopBrowser.Client
{
    public static class Helpers
    {
        private static string _version = default!;
        public static string Version { 
            get => _version;
            set => _version =
                _version is null
                    ? value ?? throw new ArgumentNullException(nameof(value))
                    : throw new InvalidOperationException($"Version already set to {_version}.");
        }

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
