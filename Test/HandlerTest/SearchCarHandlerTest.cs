using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Prueba.Application.Handlers;
using Prueba.Application.DTOs;
using Prueba.Domain.Models;
using Prueba.Infraestructure;
using Prueba.Infraestructure.Queries;
using API.Infrastructure;

namespace Test.HandlerTest
{
    public class SearchCarHandlerTest
    {
        [Fact]
        public async Task SearchCarHandler_Should_Return_Cars()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MilesCarRentalContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new MilesCarRentalContext(options))
            {
                context.Locations.Add(new Location { Id = 1, Name = "Aeropuerto Olaya Herrera", Address = "Aeropuerto Olaya Herrera", City = "Medellín" });
                context.Cars.Add(new Car { Id = 1, Brand = "Mazda", Model = 2012, State = true, Type = "Familiar", Color = "Rojo", LocationId = 1 });
                context.SaveChanges();
            }

            using (var context = new MilesCarRentalContext(options))
            {
                var query = new SearchCarQuery(new FindCarByParametersDTO { OriginName = "Aeropuerto Olaya Herrera", DestinationName = "" });
                var handler = new SearchCarHandler(context);

                // Act
                var response = await handler.Handle(query, CancellationToken.None);

                // Assert
                response.ShouldNotBeNull();
                response.Success.ShouldBeTrue();
                response.Message.ShouldBe("Lista de carros disponibles para esta locación");
                response.Result.ShouldNotBeNull();
            }
        }
    }
}
