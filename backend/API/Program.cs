using API.Extensions;
using DotNetEnv;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../../.env");

builder.Services.AddControllers();

//swag
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

app.UseMigration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())//swag
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
