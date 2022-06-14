using ArmaReforger.WorkshopBrowser.Client.Dtos;
using ArmaReforger.WorkshopBrowser.Client.Models;
using System.Threading.Tasks;

namespace ArmaReforger.WorkshopBrowser.Client.Interfaces
{
    public interface IWorkshopReader
    {
        Task<AssetsResponse> GetAllAssets(Filter filter = default);
        Task<AssetsResponse> GetPagedAssets(Pagination pagination, Filter filter = default);
    }
}
