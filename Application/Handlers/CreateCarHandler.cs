using API.Application.DTO;
using API.Application.DTOs;
using API.Domain;
using API.Infrastructure;
using API.Infrastructure.Commands;
using API.Infrastructure.Queries;
using MediatR;

namespace API.Application.Handlers
{
    public class CreateCarHandler : IRequestHandler<CreateCarCommand, PetitionResponse>
    {
        private readonly MilesCarRentalContext _context;
        public CreateCarHandler(MilesCarRentalContext context)
        {
            _context = context;
        }
        public async Task<PetitionResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {

                CarDto carDto = request.carDto;
                Car car = new Car
                {
                    Brand = carDto.Brand,
                    Color = carDto.Color,
                    Id = carDto.Id,
                    LocationId = carDto.LocationId,
                    Model = carDto.Model,
                    Type = carDto.Type,
                    State = carDto.State
                };
                _context.Add(car);
                await _context.SaveChangesAsync(cancellationToken);
                return new PetitionResponse
                {
                    Message = "Proceso Exitoso",
                    Result = car,
                    Success = true
                };
            }catch (Exception ex) {
                return new PetitionResponse
                {
                    Message = "Error en el proceso de guardado",
                    Result = null,
                    Success = false
                };
            }
        }
    }
}
