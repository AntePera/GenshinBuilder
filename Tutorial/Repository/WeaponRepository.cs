using Microsoft.EntityFrameworkCore;
using Tutorial.Data;
using Tutorial.Data.Enum;
using Tutorial.Interfaces;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly AppDbContext _context;
        public WeaponRepository(AppDbContext context) 
        {
            _context = context;
        }
        public bool Add(Weapon weapon)
        {
            _context.Add(weapon);
            return Save();
        }

        public bool Delete(Weapon weapon)
        {
            _context.Remove(weapon);
            return Save();
        }

        public async Task<IEnumerable<Weapon>> GetAll()
        {
            return await _context.Weapons.ToListAsync();
            
        }

        public async Task<Weapon> GetByIdAsync(int? id)
        {
            return await _context.Weapons.FirstOrDefaultAsync(i => i.WeaponId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Weapon weapon)
        {
            _context.Update(weapon);
            return Save();
        }
        public async Task<IEnumerable<Weapon>>filterByType(string type)
        {
           return await _context.Weapons.Where(w => (w.Type).ToString() == type).ToListAsync();
            
        }
    }
}
