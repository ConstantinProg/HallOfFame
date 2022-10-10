using System.ComponentModel.DataAnnotations;

namespace HallOfFame.Data.Transfer
{
    public class Skill
    {
        public string Name { get; set; } = string.Empty;
        [Range(1, 10, ErrorMessage = "Level must be between 1 and 10")]
        public byte Level { get; set; }
    }
}

