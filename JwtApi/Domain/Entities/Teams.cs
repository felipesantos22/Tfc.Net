using System.Text.Json.Serialization;

namespace JwtApi.Domain.Entities;

public class Teams: BaseEntity
{
    
    public string? TeamName { get; set; }
    
    [JsonIgnore] 
    public List<Matches>? Matches { get; set; }
}