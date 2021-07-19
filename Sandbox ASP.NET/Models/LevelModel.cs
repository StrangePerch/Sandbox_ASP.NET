using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox_ASP.NET.Models
{
    public class LevelModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "NameRequired"), Display(Name = "Name")]
        [StringLength(30, ErrorMessage = "NameLength", MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Display(Name = "Public")]
        public bool Public { get; set; }
        [Required(ErrorMessage = "MapRequired"), Display(Name = "Map")]
        public string Map { get; set; }
    }
}