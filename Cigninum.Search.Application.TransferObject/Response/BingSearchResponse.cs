using System.Runtime.Serialization;

namespace Cigninum.Search.Application.TransferObject.Response
{
    [DataContract]
    public class BingSearchResponse
    {
        [DataMember]
        public WebPages webPages { get; set; }
    }
}
