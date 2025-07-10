using Microsoft.EntityFrameworkCore;
using BlazorDynamicListBox.Data;
using BlazorDynamicListBox.Components;

var builder = WebApplication.CreateBuilder(args);

// Add 
// Add services to the container.

// Configure EF Core with SQLite local DB
var connStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=dynamiclistbox.db";
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connStr));

var app = builder.Build();

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