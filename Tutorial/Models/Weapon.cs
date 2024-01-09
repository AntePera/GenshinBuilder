using System.ComponentModel.DataAnnotations;
using Tutorial.Data.Enum;

namespace Tutorial.Models
{
    public class Weapon
    {

            [Key]
            public int WeaponId { get; set; }

            public string Name { get; set; }

            public WeaponType Type { get; set; }

            public Substat Substat { get; set; }

    }
}
