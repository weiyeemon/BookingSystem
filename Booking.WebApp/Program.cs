using Booking.Model;
using Booking.WebApp.Repositories;
using Booking.WebApp.Repositories.interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<BookingDBContext>(o => {
    o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters {
//        ValidateIssuerSigningKey = false,
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3be6bcc4c774d569a4af1a1159e82f134ac3b75c108589995dc19c4c47cc623b")),
//        RequireExpirationTime = true,
//        RequireSignedTokens = true,
//        ValidateLifetime = true,
//        // Additional configurations can be added as needed
//    };
//});

builder.Services.AddAuthorization();
var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Login}/{id?}");

app.Run();
