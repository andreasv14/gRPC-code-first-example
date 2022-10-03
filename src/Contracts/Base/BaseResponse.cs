using System.Runtime.Serialization;

namespace Contracts.Base;

[DataContract]
public class BaseResponse<T> where T : class
{
    [DataMember(Order = 1)]
    public bool IsSuccess { get; set; }

    [DataMember(Order = 2)]
    public string? ErrorMessage { get; set; }

    [DataMember(Order = 3)]
    public T? Data { get; set; }
}