using Cigninum.Search.Distribution.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cigninum.Search.Distribution.Core.Contract
{
    public interface ISearchResult
    {
        Task<SearcherModel> SearchLanguage(List<string> listText, string sectionGroupName);
    }
}
