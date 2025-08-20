var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();


app.MapControllers();

app.Run();