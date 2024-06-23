using Microsoft.EntityFrameworkCore;
using TechnicalInsulation.Components;
using TechnicalInsulation.Context;
using TechnicalInsulation.Repository;
using TechnicalInsulation.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddScoped<IAddElementService, AddElementService>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddDbContext<TechnicalInsulationContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();
app.Run();