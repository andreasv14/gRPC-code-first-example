using System.Runtime.Serialization;

namespace Contracts.Base;

[DataContract]
public class BaseResponse<TContractMessage> where TContractMessage : class
{
    [DataMember(Order = 1)]
    public bool IsSuccess { get; set; }

    [DataMember(Order = 2)]
    public string? ErrorMessage { get; set; }

    [DataMember(Order = 3)]
    public TContractMessage? Data { get; set; }
}