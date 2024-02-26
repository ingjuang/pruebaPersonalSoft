using API.Data;
using API.DTO;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class SearchCarService : ISearchCar
    {
        private readonly MilesCarRentalContext _context;

        public SearchCarService(MilesCarRentalContext context)
        {
            _context = context;
        }

        public async Task<PetitionResponse> FindCarByParameters(FindCarByParametersDTO findCarByParametersDTO)
        {
            Location locationforLoan = await _context.Locations.Where(x => x.Name == findCarByParametersDTO.OriginName).FirstOrDefaultAsync();
            if (!locationforLoan.Equals(null))
            {
                List<Car> CarsAvailable =  await _context.Cars.Where(x=> x.LocationId == locationforLoan.Id && x.State == true).ToListAsync();
                if(CarsAvailable.Count > 0)
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
