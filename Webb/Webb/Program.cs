using Microsoft.EntityFrameworkCore;
using Webb.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region
builder.Services.AddCors(options =>
{
    options.AddPolicy("web", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

#region
builder.Services.AddDbContext<DatabaseDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("web");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
