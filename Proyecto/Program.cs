using Proyecto.Components;
using Proyecto.Data;
using Proyecto.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<BDDirectorioDBContext>(
    options =>
    options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
                        ));
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
  
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
