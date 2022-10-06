using System.Runtime.Serialization;

namespace Contracts.Base;

[DataContract]
public class GrpcResponse<T> : IGrpcResponseBase where T : class
{
    [DataMember(Order = 1)]
    public bool IsSuccess { get; set; }

    [DataMember(Order = 2)]
    public string? ErrorMessage { get; set; }

    [DataMember(Order = 3)]
    public int StatusCode { get; set; }

    [DataMember(Order = 4)]
    public T? Data { get; set; }

    public static GrpcResponse<T> Ok(T data)
    {
        return new GrpcResponse<T>
        {
            IsSuccess = true,
            StatusCode = 200,
            ErrorMessage = default,
            Data = data
        };
    }

    public static GrpcResponse<T> Failed(string errorMessage, int statusCode)
    {
        return new GrpcResponse<T>
        {
            StatusCode = statusCode,
            Data = null,
            IsSuccess = false,
            ErrorMessage = errorMessage

        };
    }
}

[DataContract]
public class GrpcResponseBase : IGrpcResponseBase
{
    [DataMember(Order = 1)]
    public bool IsSuccess { get; set; }

    [DataMember(Order = 2)]
    public string? ErrorMessage { get; set; }

    [DataMember(Order = 3)]
    public int StatusCode { get; set; }

    public static GrpcResponseBase Ok()
    {
        return new GrpcResponseBase
        {
            IsSuccess = true,
            StatusCode = 200,
            ErrorMessage = default,
        };
    }

    public static GrpcResponseBase Failed(string errorMessage, int statusCode)
    {
        return new GrpcResponseBase
        {
            StatusCode = statusCode,
            IsSuccess = false,
            ErrorMessage = errorMessage

        };
    }
}

public interface IGrpcResponseBase
{
    [DataMember(Order = 1)]
    public bool IsSuccess { get; set; }

    [DataMember(Order = 2)]
    public string? ErrorMessage { get; set; }

    [DataMember(Order = 3)]
    public int StatusCode { get; set; }

    
}