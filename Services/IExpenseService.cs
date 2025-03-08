using Budget.Models;

namespace Budget.Services;

public interface IExpenseService
{
    Task<List<Expense>> GetExpensesAsync();
}