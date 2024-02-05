var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

/*add swagger*/
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Web api demo"));
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Routing
app.MapControllers();

app.Run();
