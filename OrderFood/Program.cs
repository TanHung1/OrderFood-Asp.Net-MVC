using OrderFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using OrderFood.Repository;
using Microsoft.AspNetCore.Identity;
using OrderFood.Data;
using OrderFood.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//dependency Injection
builder.Services.AddDbContext<OrderFoodDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderFoodDB"));
});

builder.Services.AddDbContext<OrderFoodContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderFoodContextConnection"));
});

builder.Services.AddDefaultIdentity<AccountUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<OrderFoodContext>();
builder.Services.AddScoped<UserManager<AccountUser>>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}) ;

//DI
builder.Services.AddTransient<IDishRepository, DishRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddSession();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.UseSession();

app.MapAreaControllerRoute(
    name: "default",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
