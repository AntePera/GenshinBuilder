using System.ComponentModel.DataAnnotations;

using Tutorial.Models;

namespace Tutorial.ViewModels
{
    public class EditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Set Name")]
        public string SetName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string BuildWeaponType { get; set; }

        [Display(Name = "Selected Weapon")]
        public int? WeaponId { get; set; }

        public IEnumerable<Weapon>? Weapons { get; set; }
    }
}
