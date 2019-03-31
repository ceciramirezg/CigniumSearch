using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Cigninum.Search.Cross.Core.Configuration;
using Cigninum.Search.Cross.Core.Exception;
using Cigninum.Search.Cross.Core.Util;
using Cigninum.Search.Application.TransferObject.Configuration;
using Cigninum.Search.Application.TransferObject.Response;

namespace Cigninum.Search.Application.Service
{
    public class GoogleService : IBaseService
    {
        public async Task<long> GetTotal(string text, string searcherName)
        {
            HttpClient client = new HttpClient();

            var searcherConfig = ConfigFile.GetConfigurationSectionGroup<SearcherConfig>(searcherName);
            var urlSearch = string.Format(searcherConfig.Url, searcherConfig.ApiKey, searcherConfig.Context, text);
            long total = 0;

            try
            {
                var query = await client.GetAsync(urlSearch);

                if (query != null)
                {
                    var res = await query.Content.ReadAsStringAsync();
                    var objResult = JsonSerialize.JsonToObject<GoogleSearchResponse>(res);
                    total = Convert.ToInt64(objResult.searchInformation.totalResults);
                }
                
            }
            catch (Exception ex)
            {
                new ApplicationLayerException<GoogleService>("The remote connection can not be accessed", ex);
            }

            return total;
           
        }
    }
}
