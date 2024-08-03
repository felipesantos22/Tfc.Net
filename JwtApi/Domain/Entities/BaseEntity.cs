using System.ComponentModel.DataAnnotations;

namespace JwtApi.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public virtual int Id { get; set; }
}