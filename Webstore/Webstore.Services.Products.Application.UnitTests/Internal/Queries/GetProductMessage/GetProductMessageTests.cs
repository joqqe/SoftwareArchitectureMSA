using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Webstore.Services.Products.Application.Internal.Queries.GetProductMessage;

namespace Webstore.Services.Products.Application.UnitTests.Internal.Queries.GetProductMessage
{
    public class GetProductMessageTests : TestBase
    {
        [Fact]
        public async Task Should_Return_1_Product()
        {
            var mediator = serviceProvider.GetService<IMediator>()!;

            var result = await mediator.Send(
                new GetProductMessageQuery { Id = 2 });

            Assert.Equal("Apple", result.Name);
        }
    }
}
