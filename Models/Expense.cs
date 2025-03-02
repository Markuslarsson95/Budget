using System.ComponentModel.DataAnnotations;

namespace Budget.Models;

public class Expense
{
    public int Id { get; init; }
    [MaxLength(250)]
    public required string Title { get; init; }
    public decimal Amount { get; init; }
    public DateOnly Date { get; init; }
    
    public int CategoryId { get; init; }
    public required Category Category { get; init; }
}
