using Microsoft.EntityFrameworkCore;
using Student_Management_System;

var builder = WebApplication.CreateBuilder(args);

// DB Connection
builder.Services.AddDbContext<StudentDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Controllers + JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();   //  IMPORTANT

// Middleware start here
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS yahan aayega (correct place)
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
