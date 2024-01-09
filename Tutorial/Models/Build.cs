using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tutorial.Data.Enum;

namespace Tutorial.Models
{
    public class Build
    {
        [Key]
        public int BuildId { get; set; }
        public string BuildName { get; set; }
        public string BuildDescription {  get; set; }

        [ForeignKey("Weapon")]
        public int? WeaponId { get; set; }
        public Weapon? Weapons { get; set; }
        public string WeaponName { get; set; }
        public string WeaponType { get; set;}


    }
}
