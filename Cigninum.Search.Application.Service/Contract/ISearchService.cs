using Cigninum.Search.Application.TransferObject.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cigninum.Search.Application.Service
{
    public interface ISearchService
    {
        IEnumerable<string> GetSearchers(string sectionName);

        Task<ICollection<SearchLanguageResponse>> SearchLanguage(List<string> listText, string searcherName);
                

    }
}
