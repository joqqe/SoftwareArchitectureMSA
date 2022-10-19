using MediatR;
using Webstore.Services.Products.Application;
using Webstore.Services.Products.Application.External.Queries.GetProduct;
using Webstore.Services.Products.Application.External.Queries.GetProducts;
using Webstore.Services.Products.Application.Internal.Queries.GetProductMessage;
using Webstore.Services.Products.Application.External.Commands.CreateProduct;
using Webstore.Services.Products.Contracts;
using Webstore.Services.Products.Infrastructure;

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

app.MapGet("api/external/products", async (IMediator mediator) =>
{
    return await mediator.Send(new GetProductsQuery());
})
.WithName("GetProducts");

app.MapGet("api/external/products/{id}", async (IMediator mediator, int id) =>
{
    return await mediator.Send(new GetProductQuery { Id = id });
})
.WithName("GetProduct");

app.MapPut("api/external/products", async (IMediator mediator, CreateProductCommand createProductCommand) =>
{
    return await mediator.Send(createProductCommand);
})
.WithName("CreateProduct");

app.MapGet(ProductContract.GetProductsUrl("{id}"), async (IMediator mediator, int id) =>
{
    return await mediator.Send(new GetProductMessageQuery { Id = id });
})
.WithName("GetProductMessage");

app.Run();
