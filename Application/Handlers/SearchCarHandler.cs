using API.Application.DTO;
using API.Domain;
using API.Infrastructure;
using API.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Handlers
{
    public class SearchCarHandler : IRequestHandler<SearchCarQuery, PetitionResponse>
    {

        readonly MilesCarRentalContext _context;
        public SearchCarHandler(MilesCarRentalContext context)
        {
            _context = context;
        }
        public async Task<PetitionResponse> Handle(SearchCarQuery request, CancellationToken cancellationToken)
        {
            FindCarByParametersDTO findCarByParametersDTO = request.FindCarByParametersDTO;
            Location locationforLoan = await _context.Locations.Where(x => x.Name == findCarByParametersDTO.OriginName).FirstOrDefaultAsync(cancellationToken);
            if (!locationforLoan.Equals(null))
            {
                List<Car> CarsAvailable = await _context.Cars.Where(x => x.LocationId == locationforLoan.Id && x.State == true).ToListAsync();
                if (CarsAvailable.Count > 0)
                {
                    return new PetitionResponse
                    {
                        Success = true,
                        Message = "Lista de carros disponibles para esta locación",
                        Result = CarsAvailable
                    };
                }
                else
                {
                    return new PetitionResponse
                    {
                        Success = true,
                        Message = "No hay carros disponibles para esta ubicación",
                        Result = null
                    };
                }
            }
            else
            {
                return new PetitionResponse
                {
                    Success = false,
                    Message = "Ubicación Erronea",
                    Result = null
                };
            }
        }
    }
}
