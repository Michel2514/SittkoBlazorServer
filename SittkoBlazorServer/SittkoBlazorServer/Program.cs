using Microsoft.EntityFrameworkCore;
using SittkoBlazorServer.Components;
using SittkoBlazorServer.Data;
using SittkoBlazorServer.Interfaces;
using SittkoBlazorServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("TestDB");
builder.Services.AddDbContext<TestDbContext>
    (options => options.UseNpgsql(connectionString));

builder.Services.AddTransient<ITodoListService, TodoListServices>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
