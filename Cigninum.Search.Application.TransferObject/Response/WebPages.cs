using System.Runtime.Serialization;

namespace Cigninum.Search.Application.TransferObject.Response
{
    [DataContract]
    public class WebPages
    {
        [DataMember]
        public string webSearchUrl { get; set; }
        [DataMember]
        public string totalEstimatedMatches { get; set; }
    }
}
