using Cigninum.Search.Application.Service;
using Cigninum.Search.Application.TransferObject.Response;
using Cigninum.Search.Distribution.Core.Contract;
using Cigninum.Search.Distribution.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cigninum.Search.Distribution.Core.Result
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchResult : ISearchResult
    {
        /// <summary>
        /// Search Results
        /// </summary>
        /// <param name="listText">List of texts to search</param>
        /// <param name="sectionGroupName">Section Group Name to get configuration</param>
        /// <returns>Search results object</returns>
        public async Task<SearcherModel> SearchLanguage(List<string> listText, string sectionGroupName)
        {
            SearcherModel model = new SearcherModel();
            List<SearchLanguageResponse> listResult = new List<SearchLanguageResponse>();
            List<Winner> winnerList = new List<Winner>();

            ISearchService search = new SearchService();

            var searchers = search.GetSearchers(sectionGroupName);

            foreach (var item in searchers)
            {
                listResult.AddRange(await search.SearchLanguage(listText, item));
            }            

            foreach (var item in listText)
            {
                var maxTotal = listResult.Where(s => s.Text == item).Max(s => s.Total);
                var maxObject = listResult.Where(s => s.Total == maxTotal).FirstOrDefault();

                winnerList.Add(new Winner { SearcherName = maxObject.Searcher, Text = item, Total = maxObject.Total });
            }

            var winnerMaxTotal = winnerList.Max(w => w.Total);
            var winnerMaxObject = winnerList.Where(w => w.Total == winnerMaxTotal).FirstOrDefault();

            model.SearchLanguageList = listResult;
            model.WinnerList = winnerList;
            model.WinnerMax = winnerMaxObject;
           
            return model;
        }
    }
}
