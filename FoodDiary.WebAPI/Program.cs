using FoodDiary.WebAPI.AppConfiguration.ServicesExtensions;
using FoodDiary.WebAPI.AppConfiguration.ApplicationExtensions;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogConfiguration();
builder.Services.AddVersioningConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSerilogConfiguration();

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