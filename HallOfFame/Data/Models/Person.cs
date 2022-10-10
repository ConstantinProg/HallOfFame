namespace HallOfFame.Data.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string DisplayName { get; set; } = String.Empty;
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
