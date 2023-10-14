using Microsoft.EntityFrameworkCore;
using OrderConsumerAPI.Data.Context;
using OrderConsumerAPI.MessageConsumer;
using OrderConsumerAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


var connection = builder.Configuration.GetConnectionString("ConectDB");
builder.Services.AddDbContext<SQLContext>(Options =>

                     Options.UseSqlServer(connection));


builder.Services.AddScoped<IOrderRepository, OrderRepository>();


// Configurando e injetando Classes da Pasta Repository:
var build = new DbContextOptionsBuilder<SQLContext>();
build.UseSqlServer(connection);

builder.Services.AddSingleton(new OrderRepository(build.Options));

// Injeção do RabbitMQ
builder.Services.AddHostedService<RabbitMQMessageConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
