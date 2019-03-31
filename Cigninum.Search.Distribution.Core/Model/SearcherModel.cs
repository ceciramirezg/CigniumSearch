using Cigninum.Search.Application.TransferObject.Response;
using System.Collections.Generic;

namespace Cigninum.Search.Distribution.Core.Model
{
    public class SearcherModel
    {
        public List<SearchLanguageResponse> SearchLanguageList { get; set; }

        public List<Winner> WinnerList { get; set; }

        public Winner WinnerMax { get; set; }
    }
}
