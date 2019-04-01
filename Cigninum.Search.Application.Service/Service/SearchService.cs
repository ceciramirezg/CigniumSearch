using Cigninum.Search.Application.TransferObject.Response;
using Cigninum.Search.Cross.Core.Configuration;
using Cigninum.Search.Cross.Core.Constant;
using Cigninum.Search.Cross.Core.Exception;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cigninum.Search.Application.Service
{
    public class SearchService : ISearchService
    {
        public IEnumerable<string> GetSearchers(string sectionName)
        {
            return ConfigFile.GetSectionItems(sectionName);
        }

        public async Task<ICollection<SearchLanguageResponse>> SearchLanguage(List<string> listText, string searcherName)
        {
            ICollection<SearchLanguageResponse> searchList = new List<SearchLanguageResponse>();

            Func<IBaseService> searcher;

            if (factorySearcher.TryGetValue(string.Concat(searcherName, ConstantData.SearchService.General), out searcher))
            {
                var service = searcher();
             
                foreach (string item in listText)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        var result = new SearchLanguageResponse
                        {
                            Searcher = searcherName,
                            Text = item,
                            Total = await service.GetTotal(item, searcherName)
                        };

                        searchList.Add(result);
                    }
                    else
                    {
                       new ApplicationLayerException<GoogleService>(string.Concat("No valid language ", item,"has been entered to search in ", searcherName, "."));
                      
                    }
                }
            }          

            return searchList;
        }

        private static Dictionary<string, Func<IBaseService>> factorySearcher = new Dictionary<string, Func<IBaseService>>(StringComparer.OrdinalIgnoreCase) {

            { ConstantData.SearchService.GoogleService, () => new GoogleService()},
            { ConstantData.SearchService.BingService, () => new BingService()}
         };      
      
    }
}
