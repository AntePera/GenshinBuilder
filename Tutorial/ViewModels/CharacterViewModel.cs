using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tutorial.Data.Enum;
using Tutorial.Models;

namespace Tutorial.ViewModels
{
    public class CharacterViewModel
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Element Element { get; set; }

        [Required]
        public Region Region { get; set; }

        [Required]
        public WeaponType CharacterWeaponType { get; set; }

        [ForeignKey("Build")]
        public int? BuildId { get; set; }

        public IEnumerable<Build>? Builds {get;set;}
    }
}
