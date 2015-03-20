using System.Runtime.Serialization;

namespace SOAPService2
{
    [DataContract]
    public class BookDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string[] Authors { get; set; }

        [DataMember]
        public string Publisher { get; set; }
    }
}