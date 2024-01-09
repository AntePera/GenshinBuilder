using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Tutorial.Data.Enum;

namespace Tutorial.Models
{
    public class Character
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
        public string CharacterWeaponType { get; set; }

        [ForeignKey("Build")]
        public int? BuildId { get; set; }

        public Build? Builds { get; set; }

        public IEnumerable<Build>? BuildsList{get;set;}
    }
}
