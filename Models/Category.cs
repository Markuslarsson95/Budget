using System.ComponentModel.DataAnnotations;

namespace Budget.Models;

public class Category
{
    public int Id { get; init; }
    [MaxLength(250)]
    public required string Name { get; init; }
}
