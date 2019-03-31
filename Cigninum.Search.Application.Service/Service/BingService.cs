using Cigninum.Search.Application.TransferObject.Configuration;
using Cigninum.Search.Application.TransferObject.Response;
using Cigninum.Search.Cross.Core.Configuration;
using Cigninum.Search.Cross.Core.Exception;
using Cigninum.Search.Cross.Core.Util;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cigninum.Search.Application.Service
{
    public class BingService : IBaseService
    {
        public async Task<long> GetTotal(string text, string searcherName)
        {
            HttpClient client = new HttpClient();
            long total = 0;

            var searcherConfig = ConfigFile.GetConfigurationSectionGroup<SearcherConfig>(searcherName);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", searcherConfig.ApiKey);

            var urlSearch = string.Format(searcherConfig.Url, text);
                     
            try
            {
                var query = await client.GetAsync(urlSearch);

                var res = await query.Content.ReadAsStringAsync();
                var objResult = JsonSerialize.JsonToObject<BingSearchResponse>(res);
                total = Convert.ToInt64(objResult.webPages.totalEstimatedMatches);
            }
            catch (Exception ex)
            {
                new ApplicationLayerException<GoogleService>("The remote connection can not be accessed", ex);
            }

            return total;
        }
    }
}
