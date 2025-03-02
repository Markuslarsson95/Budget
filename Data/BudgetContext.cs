using Budget.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Data;

public class BudgetContext(DbContextOptions<BudgetContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Expense> Expenses { get; set; }
}