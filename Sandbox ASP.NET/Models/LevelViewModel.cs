using System;

namespace Sandbox_ASP.NET.Models
{
    public class LevelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Public { get; set; }
        public string Map { get; set; }
    }
}