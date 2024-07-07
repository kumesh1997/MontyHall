using System.ComponentModel.DataAnnotations;

namespace MontyHall.DTO
{
    public class SimulationParametersDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "The NumberOfSimulations field must be a positive integer.")]
        public int NumberOfSimulations { get; set; }
        public bool ChangeDoor { get; set; }
    }
}
