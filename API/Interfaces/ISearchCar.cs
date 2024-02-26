using API.DTO;
using API.Models;

namespace API.Interfaces
{
    public interface ISearchCar
    {
        public Task<PetitionResponse> FindCarByParameters(FindCarByParametersDTO findCarByParametersDTO);
    }
}
