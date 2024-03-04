using Prueba.Application.DTOs;
using MediatR;

namespace Prueba.Infraestructure.Queries
{
    public record SearchCarQuery(FindCarByParametersDTO FindCarByParametersDTO) : IRequest<PetitionResponse>;
}
