using System.Runtime.Serialization;

namespace Cigninum.Search.Application.TransferObject.Response
{
    [DataContract]
    public class SearchInformation
    {
        [DataMember]
        public double searchTime { get; set; }
        [DataMember]
        public string formattedSearchTime { get; set; }
        [DataMember]
        public string totalResults { get; set; }
        [DataMember]
        public string formattedTotalResults { get; set; }
    }
}
