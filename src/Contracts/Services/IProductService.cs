﻿using System.ServiceModel;
using Contracts.Base;
using Contracts.Requests;
using Contracts.Responses;
using ProtoBuf.Grpc;

namespace Contracts.Services;

[ServiceContract(Name = "UserService")]
public interface IProductService
{
    [OperationContract]
    Task<GrpcResponse<AddProductReply>> AddProductAsync(AddProductRequest request, CallContext context = default);

    [OperationContract]
    Task<GrpcResponseBase> GetProduct(AddProductRequest request, CallContext context = default);
}