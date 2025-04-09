using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using UserProfileApi.Infrastructure.Data;
using UserProfileApi.Infrastructure.Services;
using UserProfileApi.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configure database context to use postgres
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserProfileConnection")));

// Register UserProfileService, IUserProfileService dependency
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Auth0 authentication and JWT bearer token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/"; // set authority
        options.Audience = builder.Configuration["Auth0:Audience"]; // set expected audiance
    });

// Securing endpoint
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();