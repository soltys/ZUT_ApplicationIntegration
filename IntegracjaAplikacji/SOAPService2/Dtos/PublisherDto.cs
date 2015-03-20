using System.Runtime.Serialization;

namespace SOAPService2
{
    [DataContract]
    public class PublisherDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Url { get; set; }
    }
}