using Microsoft.EntityFrameworkCore;
using QuranDataLayer.Context;
using QuranDataLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddScoped<ChapterRepository>();
var app = builder.Build();
app.UseStaticFiles();   
app.MapControllers();
app.Run();
