using Tutorial.Models;

namespace Tutorial.Interfaces
{
    public interface IWeaponRepository
    {
        Task<IEnumerable<Weapon>> GetAll();
        Task<Weapon> GetByIdAsync(int? id);
        Task<IEnumerable<Weapon>>filterByType(string type);
        bool Add( Weapon weapon);
        bool Update( Weapon weapon);
        bool Delete( Weapon weapon );
        bool Save();
    }
}
;