using Application.Interfaces;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Interfaces;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);

// Register repositories
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

// Register services
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Swagger is now available in all environments
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Feedback Service API");
    c.RoutePrefix = string.Empty;
});

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
