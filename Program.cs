using Budget.Components;
using Budget.Data;
using Budget.Models;
using Budget.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BudgetContext>(optionsBuilder =>
{
    optionsBuilder
        .UseNpgsql(connectionString)
        .UseAsyncSeeding(async (context, _, ct) =>
        {
            var categoriesToSeed = new List<Category>()
            {
                new() { Id = 1, Name = "Hushåll" },
                new() { Id = 2, Name = "Mat" }
            };

            var contains = await context.Set<Category>().ContainsAsync(categoriesToSeed[0], ct);
            if (!contains)
            {
                context.Set<Category>().AddRange(categoriesToSeed);
                await context.SaveChangesAsync(ct);
            }
        });
});
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

var app = builder.Build();

await using (var serviceScope = app.Services.CreateAsyncScope())
await using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<BudgetContext>())
{
    await dbContext.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();