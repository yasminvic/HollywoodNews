using HollywoodNoticias.Domain.Contracts.IRepositories;
using HollywoodNoticias.Infra.Data.Repository.Repositories;
using HollywoodNoticias.ProjetoMVC.Helper;
using HollywoodNoticias.Application.Service.SQLServerServices;
using HollywoodNoticias.Domain.Contracts.IServices;
using Microsoft.EntityFrameworkCore;
using HollywoodNoticias.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextoDatabase>
    (options => options.UseSqlServer("Server=LAPTOP-EBG33A6E\\SQLEXPRESS;Database=HollywoodNews;User Id=sa;Password=gibi2016;TrustServerCertificate=True; MultipleActiveResultSets=True"));

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<INoticiaService, NoticiaService>();

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<INoticiaRepository, NoticiaRepository>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
