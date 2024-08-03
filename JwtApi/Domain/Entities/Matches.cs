using System.Text.Json.Serialization;

namespace JwtApi.Domain.Entities;

public class Matches: BaseEntity
{
    public int? HomeTeamId { get; set; }
    public int? HomeTeamGoals { get; set; }
    public int? AwayTeamId { get; set; }
    public int? AwayTeamGoals { get; set; }
    public bool? InProgress { get; set; }
    
    [JsonIgnore] 
    public Teams? Teams { get; set; }
}