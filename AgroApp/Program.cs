using AgroApp.Data;
using AgroApp.Models;
using AgroApp.Repositories;
using AgroApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AgroAppDatabase");
var connectionStringIdentity = builder.Configuration.GetConnectionString("AgroAppIdentityDatabase");

//Po³¹czenie z baz¹ g³ówn¹
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString,
    sqlServerOptionsAction : sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));

//Po³¹czenie z baz¹ u¿ytkowników
/*builder.Services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(connectionStringIdentity,
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));*/
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 2;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IFieldRepository, FieldRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IFarmRepository, FarmRepository>();
builder.Services.AddTransient<IEntryRepository, EntryRepository>();
builder.Services.AddTransient<IMachineRepository, MachineRepository>();
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IMachineServiceRepository, MachineServiceRepository>();

builder.Services.AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
