using Budget.Data;
using Budget.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Services;

public class ExpenseService(BudgetContext db) : IExpenseService
{
    public async Task<List<Expense>> GetExpensesAsync()
    {
        var expenses = await db.Expenses.Include(e => e.Category).ToListAsync();
        return expenses;
    }
}