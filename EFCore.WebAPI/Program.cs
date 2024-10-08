using EFCore.Repositorio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();

// Inje??o do DBCONTEXT no projeto
builder.Services
    .AddDbContext<HeroiContext>(
        context =>
        {
            var configuration = builder.Configuration.GetConnectionString("DefaultConnection");
            context.UseMySql(configuration, ServerVersion.AutoDetect(configuration));
            context.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
