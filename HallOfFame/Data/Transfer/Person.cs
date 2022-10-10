namespace HallOfFame.Data.Transfer
{
    public class Person
    {
        public long? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
