using Microsoft.EntityFrameworkCore;
using SocialAppForIbb.Dal;
using SocialAppForIbb.Rep;
using SocialAppForIbb.UI.Models.ViewModels;
using SocialAppForIbb.Uow;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context
builder.Services.AddDbContext<Context>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("SocialApp")));

// Uow
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Rep
builder.Services.AddScoped<IFollowRepository, FollowRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Models
builder.Services.AddScoped<FollowViewModel>();
builder.Services.AddScoped<PostViewModel>();
builder.Services.AddScoped<UserViewModel>();



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
