using System.Runtime.Serialization;

namespace Contracts.Common;

[DataContract]
public class BaseContractMessage
{
    [DataMember(Order = 1)]
    public string Message { get; set; }
}