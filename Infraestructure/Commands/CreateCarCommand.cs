using API.Application.DTO;
using API.Application.DTOs;
using MediatR;

namespace API.Infrastructure.Commands
{
    public record CreateCarCommand(CarDto carDto) 
        : IRequest<PetitionResponse>;
}
