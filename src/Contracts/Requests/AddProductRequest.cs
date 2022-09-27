﻿using System.Runtime.Serialization;

namespace Contracts.Requests;

[DataContract]
public class AddProductRequest
{
    [DataMember(Order = 1)]
    public string? Name { get; set; }

    [DataMember(Order = 2)]
    public string? Description { get; set; }
}