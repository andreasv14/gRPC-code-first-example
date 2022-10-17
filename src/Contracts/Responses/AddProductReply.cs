using System.Runtime.Serialization;
using Contracts.Models;

namespace Contracts.Responses;

[DataContract]
public class AddProductReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; }

    [DataMember(Order = 2)]
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
}