using Microsoft.EntityFrameworkCore;
using BookStore.WebAPI.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using BookStore.WebAPI.Services;
using BookStore.WebAPI.Data;
using Microsoft.IdentityModel.Logging;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<BookStoreDBContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(
        builder.Configuration.GetConnectionString("BookStoreDB"))
);

// Add cors
builder.Services.AddCors();

//Do the service register here and extra stuff you want
builder.Services.AddLogging();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(Program));

// Configurations
//builder.Services.Configure<AppSettings>(builder.Configuration);

// Business Services
builder.Services.AddScoped<IBookService, BookService>();

//File Logger
//builder.Logging.AddFile(builder.Configuration.GetSection("Logging"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapDefaultControllerRoute();
app.UseHttpsRedirection();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();

// Enable middleware to serve swagger-ui assets(HTML, JS, CSS etc.)
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "RealWorld API V1"));

app.Run();