using System.Runtime.Serialization;

namespace Contracts.Base;

[DataContract]
public class BaseResponse
{
    [DataMember(Order = 1)]
    public bool IsSuccess { get; set; }

    [DataMember(Order = 2)]
    public string? ErrorMessage { get; set; }

    [DataMember(Order = 3)]
    public IContractMessage? Data { get; set; }
}