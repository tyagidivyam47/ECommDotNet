using Microsoft.EntityFrameworkCore;
using WebApplicationECOM.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("application", (builder) =>
    {
        builder.WithOrigins("https://localhost:7274")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});

//For API Versioning
//builder.Services.AddApiVersioning();  For Simple Type
//builder.Services.AddApiVersioning(a => a.ApiVersionReader = new MediaTypeApiVersionReader()); // For Media Type API Versioning

//For SQL Server
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//For PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.UseCors("application");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
