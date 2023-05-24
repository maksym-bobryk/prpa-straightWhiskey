using PRPA.DBContext;
using PRPA.RepositoriesInterfaces;
using PRPA.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentServiceRepository, AppointmentServiceRepository>();
builder.Services.AddScoped<IBarberRepository, BarberRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICosmeticsRequestRepository, CosmeticsRequestRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-49IUG3K;Initial Catalog=BarberShop;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
});

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
