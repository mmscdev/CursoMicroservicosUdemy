using GeekShopping.OrderAPI.MessageConsumer;
using GeekShopping.OrderAPI.Model.Context;
using GeekShopping.OrderAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.
    UseMySql(connection,
            new MySqlServerVersion(
                new Version(8, 0, 5))));

var builder2 = new DbContextOptionsBuilder<MySQLContext>();

builder2.UseMySql(connection,
            new MySqlServerVersion(
                new Version(8, 0, 5)));
builder.Services.AddSingleton(new OrderRepository(builder2.Options));

builder.Services.AddControllers();
builder.Services.AddHostedService<RabbitMQCheckoutConsumer>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
