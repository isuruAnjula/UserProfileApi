using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using UserProfileApi.Data;
using UserProfileApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure database context to use postgres
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserProfileConnection")));

// Register UserProfileService dependency
builder.Services.AddScoped<UserProfileService>();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

// Sample test endpoint
app.MapGet("/", () => "/ API is up and running!").RequireAuthorization();

// Endpoint to retrive authenticated user profile
app.MapGet("/profile", (HttpContext httpContext, UserProfileService service) =>
{
    // Extract user id from authentication claim
    var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (userId == null) return Results.Unauthorized();

    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();

    // Return relevent user id
    return Results.Ok(new { UserId = userId });

}).RequireAuthorization();

app.Run();