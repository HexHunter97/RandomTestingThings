using ArmaReforger.WorkshopBrowser.Client.Dtos;
using ArmaReforger.WorkshopBrowser.Client.Interfaces;
using ArmaReforger.WorkshopBrowser.Client.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmaReforger.WorkshopBrowser.Client.Services
{
    public class WorkshopReader : IWorkshopReader
    {
        private const string ArmaWorkshopPath = "workshop-api/api/v3.0/";
        private const string Assets = ArmaWorkshopPath + "assets";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WorkshopReader> _logger;

        public WorkshopReader(IHttpClientFactory httpClientFactory, ILogger<WorkshopReader> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public Task<AssetsResponse> GetAllAssets(Filter filter = default)
            => GetAssets(filter, null);

        public Task<AssetsResponse> GetPagedAssets(Pagination pagination, Filter filter = default)
            => GetAssets(filter, pagination);

        private async Task<AssetsResponse> GetAssets(Filter filter, Pagination? pagination)
        {
            using var client = _httpClientFactory.CreateClient(Constants.Clients.Echo);

            client.DefaultRequestHeaders.TryAddWithoutValidation(WorkshopBrowser.Shared.Constants.ProxyHeaderName, "asd");

            return (await client.GetFromJsonAsync<AssetsResponse>(BuildUrl(Assets, filter, pagination)))!;
        }

        private string BuildUrl(string baseUrl, Filter filter, Pagination? pagination)
        {
            var queryString = new StringBuilder();

            if (pagination.HasValue)
            {
                queryString.AppendQueryString(pagination.Value.Limit.ToString(), nameof(Pagination.Limit));
                queryString.AppendQueryString(pagination.Value.Offset.ToString(), nameof(Pagination.Offset));
            }

            queryString.AppendQueryString(filter.Search, nameof(Filter.Search));
            queryString.AppendQueryString(filter.Blocked.ToString(), nameof(Filter.Blocked));
            queryString.AppendQueryString(filter.Private.ToString(), nameof(Filter.Private));
            queryString.AppendQueryString(filter.Unlisted.ToString(), nameof(Filter.Unlisted));

            queryString.Remove(0, 1);

            return $"{baseUrl}?{queryString}";
        }
    }
}
