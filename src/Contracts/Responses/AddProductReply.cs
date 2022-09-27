using System.Runtime.Serialization;
using Contracts.Base;

namespace Contracts.Responses;

[DataContract]
public class AddProductReply : IContractMessage
{
    [DataMember(Order = 1)]
    public string Message { get; set; }
}