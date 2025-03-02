namespace Budget.Models;

public class Expense
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    
    public int CategoryId { get; set; }
    public required Category Category { get; set; }
}
