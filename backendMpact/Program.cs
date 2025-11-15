using backendMpact.Data;
using backendMpact.Repositories;
using backendMpact.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDev",
        policy => policy
            .WithOrigins("https://localhost:7071") // Blazor Server URL
            .AllowAnyHeader()
            .AllowAnyMethod());
});
// JWT values must match UserService constants
var jwtKey = "4bb6d1dfbafb64a681139d1586b6f1160d18159afd57c8c79136d7490630407c"; // same as UserService
var jwtIssuer = "MyBackendApp";
var jwtAudience = "BlazorClient";

// ✅ Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
})
.AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "API", 
        Version = "v1" 
    });
});

var app = builder.Build();
app.UseCors("AllowBlazorDev");
// Seed first admin
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userService = services.GetRequiredService<IUserService>();
    await userService.SeedFirstAdmin();
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // ✅ Must come before Authorization
app.UseAuthorization();

app.MapControllers();
app.Run();
