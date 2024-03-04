using API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Prueba.Application.DTOs;
using Prueba.Application.Handlers;
using Prueba.Domain.Models;
using Prueba.Infraestructure.Commands;
using Prueba.Infraestructure.Queries;
using System;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.HandlerTest
{
    public class CreateCarHandlerTest
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
                context.Locations.Add(new Location { Id = 2, Name = "CC Oviedo", Address = "Cll 54 # 21 -22", City = "Medellín" });
                context.SaveChanges();
            }

            using (var context = new MilesCarRentalContext(options))
            {
                var command = new CreateCarCommand(new CarDto { Id = 2, Brand = "Mercedes", Model = 2002, State = true, Type = "Deportivo", Color = "Plateado", LocationId = 2 });
                var handler = new CreateCarHandler(context);

                // Act
                var response = await handler.Handle(command, CancellationToken.None);

                // Assert
                response.ShouldNotBeNull();
                response.Success.ShouldBeTrue();
                response.Message.ShouldBe("Proceso Exitoso");
                response.Result.ShouldNotBeNull();
            }
        }
    }
}
