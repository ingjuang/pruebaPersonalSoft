using Prueba.Application.DTOs;
using MediatR;

namespace Prueba.Infraestructure.Commands
{
    public record CreateCarCommand(CarDto carDto) 
        : IRequest<PetitionResponse>;
}
