using MontyHall.DTO;

namespace MontyHall.Services
{
    public class MontyHallSimulationService : IMontyHallSimulationService
    {
        private readonly Random _random = new Random();
        public SimulationResultsDto SimulateGames(int numberOfSimulations, bool changeDoor)
        {
            int winsWithoutChanging = 0;
            int winsWithChanging = 0;

            for (int i = 0; i < numberOfSimulations; i++)
            {
                int carPosition = _random.Next(3); // 0, 1, or 2 (positions of doors)
                int initialChoice = _random.Next(3); // Player's initial choice

                int openedDoor;
                do
                {
                    openedDoor = _random.Next(3);
                } while (openedDoor == carPosition || openedDoor == initialChoice); // Presenter opens a door with a goat

                if (!changeDoor)
                {
                    if (initialChoice == carPosition)
                    {
                        winsWithoutChanging++;
                    }
                }
                else
                {
                    int newChoice;
                    do
                    {
                        newChoice = _random.Next(3);
                    } while (newChoice == initialChoice || newChoice == openedDoor);

                    if (newChoice == carPosition)
                    {
                        winsWithChanging++;
                    }
                }
            }

            return new SimulationResultsDto
            {
                NumberOfWinsWithoutChanging = winsWithoutChanging,
                NumberOfWinsWithChanging = winsWithChanging
            };
        }
    }
}
