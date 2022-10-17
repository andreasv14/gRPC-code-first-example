using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

namespace Contracts.Models;

[DataContract]
public class Category
{
    [DataMember(Order = 1)] 
    public string Description { get; set; }
}