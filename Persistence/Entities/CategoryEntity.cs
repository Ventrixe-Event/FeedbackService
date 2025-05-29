using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
