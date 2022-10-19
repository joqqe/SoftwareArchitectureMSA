using MediatR;
using Webstore.Services.Orders.Application;
using Webstore.Services.Orders.Application.External.Commands.CreateOrderCommand;
using Webstore.Services.Orders.Application.External.Queries.GetOrders;
using Webstore.Services.Orders.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/orders", async (IMediator mediator) =>
{
    return await mediator.Send(new GetOrdersQuery());
})
.WithName("GetOrders");

app.MapPut("/orders", async (IMediator mediator, CreateOrderCommand CreateOrderCommand) =>
{
    return await mediator.Send(CreateOrderCommand);
})
.WithName("CreateOrder");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}