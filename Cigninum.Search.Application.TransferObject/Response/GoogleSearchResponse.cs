using System.Runtime.Serialization;

namespace Cigninum.Search.Application.TransferObject.Response
{
    [DataContract]
    public class GoogleSearchResponse
    {
        [DataMember]
        public SearchInformation searchInformation { get; set; }
    }
}
