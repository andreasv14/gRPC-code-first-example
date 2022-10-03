﻿using System.Runtime.Serialization;
using Contracts.Base;
using Contracts.Common;

namespace Contracts.Responses;

[DataContract]
public class AddProductReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; }
}