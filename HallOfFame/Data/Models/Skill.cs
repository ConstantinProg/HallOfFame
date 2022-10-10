﻿using System.Diagnostics.CodeAnalysis;

namespace HallOfFame.Data.Models
{
    public class Skill
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte Level { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; } = new Person();
    }
}
