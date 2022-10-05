using System.Runtime.Serialization;

namespace Contracts.Responses;

[DataContract]
public class AddProductReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; }
}