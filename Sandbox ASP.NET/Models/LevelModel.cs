using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox_ASP.NET.Models
{
    public class LevelModel
    {
        [Key] public Guid Id { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.LevelModel.NameRequired),
            ErrorMessageResourceType = typeof(Resources.LevelModel)
        )]
        [Display(Name = "Name", ResourceType = typeof(Resources.LevelModel)
        )]
        [StringLength(30, MinimumLength = 3,
            ErrorMessageResourceName = nameof(Resources.LevelModel.NameLength),
            ErrorMessageResourceType = typeof(Resources.LevelModel)
        )]
        public string Name { get; set; }

        [Display(Name = "Author", ResourceType = typeof(Resources.LevelModel))]
        public string Author { get; set; }

        [Display(Name = "Public", ResourceType = typeof(Resources.LevelModel))]
        public bool Public { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.LevelModel.MapRequired),
            ErrorMessageResourceType = typeof(Resources.LevelModel)
        )]
        [Display(Name = "Map", ResourceType = typeof(Resources.LevelModel))]
        public string Map { get; set; }
        
    }
}