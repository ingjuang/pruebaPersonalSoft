using API.Application.DTO;
using MediatR;

namespace API.Infrastructure.Queries
{
    public record SearchCarQuery(FindCarByParametersDTO FindCarByParametersDTO) : IRequest<PetitionResponse>;
}
