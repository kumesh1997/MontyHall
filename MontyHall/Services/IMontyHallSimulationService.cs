using MontyHall.DTO;

namespace MontyHall.Services
{
    public interface IMontyHallSimulationService
    {
        public SimulationResultsDto SimulateGames(int numberOfSimulations, bool changeDoor);
    }
}
