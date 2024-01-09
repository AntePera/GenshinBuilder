using System.ComponentModel.DataAnnotations;
using Tutorial.Data.Enum;
using Tutorial.Models;

namespace Tutorial.ViewModels
{
    public class BuildViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Set Name")]
        public string SetName { get; set; }
        public string? Description { get; set; }
        public string BuildWeaponType { get; set; }

        [Display(Name = "Selected Weapon")]
        public int? WeaponId { get; set; }

        public IEnumerable<Weapon>? Weapons { get; set; }
        [Display(Name = "Selected Character")]
        public int? CharacterId { get; set; }
        public IEnumerable<Character>? Characters { get; set; }
    }
}
